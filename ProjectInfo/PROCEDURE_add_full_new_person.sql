CREATE PROCEDURE public.add_full_new_person(IN "Person_FirstName" "char", IN "Person_LastName" "char", IN "Person_MidleName" "char", 
IN "Person_Email" "char", IN "Person_Birthday" date, IN "Person_IsWorking" boolean, IN "Person_IsMaried" boolean, 
IN "Person_NowPlaceLiving" "char", IN "Person_HireDate" date, IN "Person_Login" "char", IN "Person_Password_Hash" text,
IN "Person_Role" "char", IN "Person_Password_Salt" text)
LANGUAGE 'plpgsql'
AS $BODY$


DECLARE
	salt TEXT;
    hashed_password TEXT;
BEGIN

-- Проверка на существование пользователя с таким Email в Person
IF EXISTS (SELECT 1 FROM "Person" WHERE "Email" = "Person_Email") THEN
          RAISE EXCEPTION 'User with Email % already authorized', "Person_Email";
END IF;

-- Проверка на существование пользователя с таким Login в Authorization
 IF EXISTS (SELECT 1 FROM "Authorization" WHERE "Login" = "Person_Login") THEN
        RAISE EXCEPTION 'User with Login % already authorized', "Person_Login";
    END IF;

-- вставка данных нового работника
INSERT INTO "Person" ("FirstName", "LastName", "MidleName", "Phone", "Email", "Birthday", "IsWorking",
"IsMarried", "NowPlaceLiving", "HireDate","CreateAt") VALUES("Person_FirstName", "Person_LastName", "Person_MidleName", "Person_Phone", "Person_Email", "Person_Birthday", "Person_IsWorking",
"Person_IsMarried", "Person_NowPlaceLiving", "Person_HireDate", CURRENT_TIMESTAMP) RETURNING "ID" INTO new_person_id;

-- Генерация соли
salt := bcrypt_gensalt();
-- Хеширование пароля
hashed_password := bcrypt_hashpw("Person_Password", salt);

INSERT INTO "Authorization" ("Login", "PasswordHash", "PasswordSalt", "Role","CreateAt")
VALUES ("Person_Login", hashed_password, salt, "Person_Role", CURRENT_TIMESTAMP);

END;

$BODY$;
ALTER PROCEDURE public.add_full_new_person("char", "char", "char", "char", date, boolean, boolean, "char", date, "char", text, "char", text)
    OWNER TO postgres;

COMMENT ON PROCEDURE public.add_full_new_person("char", "char", "char", "char", date, boolean, boolean, "char", date, "char", text, "char", text)
    IS 'adding new person and other person data to tables';