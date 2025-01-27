CREATE OR REPLACE PROCEDURE public.add_full_new_person_and_authorized(IN "Person_FirstName" VARCHAR(100), IN "Person_LastName" VARCHAR(100), IN "Person_MidleName" VARCHAR(100), 
IN "Person_Email" VARCHAR(100),IN "Person_Phone" VARCHAR(20), IN "Person_Birthday" date, IN "Person_IsWorking" boolean, IN "Person_IsMarried" boolean, 
IN "Person_NowPlaceLiving" VARCHAR(200), IN "Person_HireDate" date, IN "Person_Login" VARCHAR(100), IN "Person_Password" text,
IN "Person_Role" VARCHAR(100),OUT new_person_id BIGINT)
LANGUAGE 'plpgsql'
AS $BODY$


DECLARE
	salt TEXT;
    hashed_password TEXT;
	new_authorization_id BIGINT;
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


hashed_password := "Person_Password";

INSERT INTO "Authorization" ("Login", "PasswordHash", "Role","CreateAt")
VALUES ("Person_Login", hashed_password, "Person_Role", CURRENT_TIMESTAMP) RETURNING "ID" INTO new_authorization_id;

INSERT INTO "Person/Authorization" ("Person_ID","Authorization_ID")
VALUES(new_person_id,new_authorization_id);

END;

$BODY$;