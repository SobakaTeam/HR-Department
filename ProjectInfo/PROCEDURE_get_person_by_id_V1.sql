CREATE OR REPLACE PROCEDURE get_person_by_id (
    IN person_id_param BIGINT,
    OUT person_data REFCURSOR
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Открываем курсор для данных о пользователе
     OPEN person_data FOR
    SELECT
        p."ID" AS "Person_ID",
	    p."FirstName",
	    p."LastName",
	    p."MidleName",
	    p."Phone",
	    p."Email",
	    p."Birthday",
	    p."CreateAt" AS "Person_CreateAt",
	    p."UpdateAt" AS "Person_UpdateAt",
	    p."IsWorking",
	    p."IsMarried",
	    p."NowPlaceLiving",
	    p."HireDate"
    FROM
        "Person" p
   WHERE p."ID" = person_id_param;


END;
$$;
COMMENT ON PROCEDURE public.get_person_by_id(BIGINT, REFCURSOR)
    IS 'get person by id';