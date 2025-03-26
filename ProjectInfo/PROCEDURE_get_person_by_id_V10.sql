CREATE TABLE "PersonAuthorization"(
    "ID" BIGINT PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Authorization_ID" BIGINT NOT NULL
);
CREATE TABLE "Person"(
    "ID" BIGINT PRIMARY KEY,
    "FirstName" VARCHAR(255) NULL,
    "LastName" VARCHAR(255) NULL,
    "MidleName" VARCHAR(255) NULL,
    "Phone" VARCHAR(255) NULL,
    "Email" VARCHAR(255) NULL,
    "Birthday" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL,
    "IsWorking" BOOLEAN NULL,
    "IsMarried" BOOLEAN NULL,
    "NowPlaceLiving" TEXT NULL,
    "HireDate" DATE NULL
);
ALTER TABLE
    "Person" ADD CONSTRAINT "person_email_unique" UNIQUE("Email");
CREATE TABLE "Child"(
    "ID" BIGINT PRIMARY KEY,
    "FirstName" VARCHAR(255) NULL,
    "Surname" VARCHAR(255) NULL,
    "MidleName" VARCHAR(255) NULL,
    "Birthday" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "PersonСhild"(
    "ID" BIGINT PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Child_ID" BIGINT NOT NULL
);
CREATE TABLE "Position"(
    "ID" BIGINT PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Desctription" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "PersonPosition"(
    "ID" BIGINT PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Position_ID" BIGINT NOT NULL
);
CREATE TABLE "Department"(
    "ID" BIGINT PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Description" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdatbiginteAt" DATE NULL
);
CREATE TABLE "PersonDepartment"(
    "ID" BIGINT PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Department_ID" BIGINT NOT NULL
);
CREATE TABLE "Vacation"(
    "ID" BIGINT PRIMARY KEY,
    "BeginDate" DATE NOT NULL,
    "EndDate" DATE NULL,
    "VacationType" VARCHAR(255) NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "PersonVacation"(
    "ID" BIGINT PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Vacation_ID" BIGINT NOT NULL
);
CREATE TABLE "Organization"(
    "ID" BIGINT PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "RegistrDate" DATE NOT NULL,
    "Adress" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "DepartmentOrganization"(
    "ID" BIGINT PRIMARY KEY,
    "Department_ID" BIGINT NOT NULL,
    "Organization_ID" BIGINT NOT NULL
);
CREATE TABLE "Salary"(
    "ID" BIGINT PRIMARY KEY,
    "Amount" DECIMAL(8, 2) NOT NULL,
    "BeginDate" DATE NOT NULL,
    "EndDate" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "PersonSalary"(
    "ID" BIGINT PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Salary_ID" BIGINT NOT NULL
);
CREATE TABLE "Authorization"(
    "ID" BIGINT PRIMARY KEY,
    "Login" VARCHAR(255) NOT NULL,
    "PasswordHash" TEXT NOT NULL,
    "PasswordSalt" TEXT NULL,
    "Role" VARCHAR(255) NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAT" DATE NULL
);
ALTER TABLE
    "Authorization" ADD CONSTRAINT "authorization_login_unique" UNIQUE("Login");
ALTER TABLE
    "PersonVacation" ADD CONSTRAINT "personvacation_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "PersonAuthorization" ADD CONSTRAINT "personauthorization_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "PersonСhild" ADD CONSTRAINT "personchild_child_id_foreign" FOREIGN KEY("Child_ID") REFERENCES "Child"("ID");
ALTER TABLE
    "PersonPosition" ADD CONSTRAINT "personposition_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "PersonСhild" ADD CONSTRAINT "personchild_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "PersonSalary" ADD CONSTRAINT "personsalary_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "PersonPosition" ADD CONSTRAINT "personposition_position_id_foreign" FOREIGN KEY("Position_ID") REFERENCES "Position"("ID");
ALTER TABLE
    "PersonDepartment" ADD CONSTRAINT "persondepartment_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "PersonVacation" ADD CONSTRAINT "personvacation_vacation_id_foreign" FOREIGN KEY("Vacation_ID") REFERENCES "Vacation"("ID");
ALTER TABLE
    "DepartmentOrganization" ADD CONSTRAINT "departmentorganization_department_id_foreign" FOREIGN KEY("Department_ID") REFERENCES "Department"("ID");
ALTER TABLE
    "DepartmentOrganization" ADD CONSTRAINT "departmentorganization_organization_id_foreign" FOREIGN KEY("Organization_ID") REFERENCES "Organization"("ID");
ALTER TABLE
    "PersonSalary" ADD CONSTRAINT "personsalary_salary_id_foreign" FOREIGN KEY("Salary_ID") REFERENCES "Salary"("ID");
ALTER TABLE
    "PersonAuthorization" ADD CONSTRAINT "personauthorization_autorization_id_foreign" FOREIGN KEY("Authorization_ID") REFERENCES "Authorization"("ID");
ALTER TABLE
    "PersonDepartment" ADD CONSTRAINT "persondepartment_department_id_foreign" FOREIGN KEY("Department_ID") REFERENCES "Department"("ID");

    -- Add auto incriment to ID properties
    ALTER TABLE "PersonAuthorization" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Person" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Child" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "PersonСhild" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Position" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "PersonPosition" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Department" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "PersonDepartment" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Vacation" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "PersonVacation" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Organization" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "DepartmentOrganization" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Salary" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "PersonSalary" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;

    ALTER TABLE "Authorization" ALTER COLUMN "ID" ADD GENERATED BY DEFAULT AS IDENTITY;