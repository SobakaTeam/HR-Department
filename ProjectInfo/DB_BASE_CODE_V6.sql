CREATE TABLE "Person/Authorization"(
    "ID" SERIAL PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Authorization_ID" BIGINT NOT NULL
);
CREATE TABLE "Person"(
    "ID" SERIAL PRIMARY KEY,
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
    "ID" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(255) NULL,
    "Surname" VARCHAR(255) NULL,
    "MidleName" VARCHAR(255) NULL,
    "Birthday" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "Person/child"(
    "ID" SERIAL PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Child_ID" BIGINT NOT NULL
);
CREATE TABLE "Position"(
    "ID" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Desctription" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "Person/Position"(
    "ID" SERIAL PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Position_ID" BIGINT NOT NULL
);
CREATE TABLE "Department"(
    "ID" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "Description" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdatbiginteAt" DATE NULL
);
CREATE TABLE "Person/Department"(
    "ID" SERIAL PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Department_ID" BIGINT NOT NULL
);
CREATE TABLE "Vacation"(
    "ID" SERIAL PRIMARY KEY,
    "BeginDate" DATE NOT NULL,
    "EndDate" DATE NULL,
    "VacationType" VARCHAR(255) NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "Person/Vacation"(
    "ID" SERIAL PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Vacation_ID" BIGINT NOT NULL
);
CREATE TABLE "Organization"(
    "ID" SERIAL PRIMARY KEY,
    "Name" VARCHAR(255) NOT NULL,
    "RegistrDate" DATE NOT NULL,
    "Adress" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "Department/Organization"(
    "ID" SERIAL PRIMARY KEY,
    "Department_ID" BIGINT NOT NULL,
    "Organization_ID" BIGINT NOT NULL
);
CREATE TABLE "Salary"(
    "ID" SERIAL PRIMARY KEY,
    "Amount" DECIMAL(8, 2) NOT NULL,
    "BeginDate" DATE NOT NULL,
    "EndDate" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
CREATE TABLE "Person/Salary"(
    "ID" SERIAL PRIMARY KEY,
    "Person_ID" BIGINT NOT NULL,
    "Salary_ID" BIGINT NOT NULL
);
CREATE TABLE "Authorization"(
    "ID" SERIAL PRIMARY KEY,
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
    "Person/Vacation" ADD CONSTRAINT "person/vacation_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "Person/Authorization" ADD CONSTRAINT "person/authorization_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "Person/child" ADD CONSTRAINT "person/child_child_id_foreign" FOREIGN KEY("Child_ID") REFERENCES "Child"("ID");
ALTER TABLE
    "Person/Position" ADD CONSTRAINT "person/position_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "Person/child" ADD CONSTRAINT "person/child_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "Person/Salary" ADD CONSTRAINT "person/salary_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "Person/Position" ADD CONSTRAINT "person/position_position_id_foreign" FOREIGN KEY("Position_ID") REFERENCES "Position"("ID");
ALTER TABLE
    "Person/Department" ADD CONSTRAINT "person/department_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("ID");
ALTER TABLE
    "Person/Vacation" ADD CONSTRAINT "person/vacation_vacation_id_foreign" FOREIGN KEY("Vacation_ID") REFERENCES "Vacation"("ID");
ALTER TABLE
    "Department/Organization" ADD CONSTRAINT "department/organization_department_id_foreign" FOREIGN KEY("Department_ID") REFERENCES "Department"("ID");
ALTER TABLE
    "Department/Organization" ADD CONSTRAINT "department/organization_organization_id_foreign" FOREIGN KEY("Organization_ID") REFERENCES "Organization"("ID");
ALTER TABLE
    "Person/Salary" ADD CONSTRAINT "person/salary_salary_id_foreign" FOREIGN KEY("Salary_ID") REFERENCES "Salary"("ID");
ALTER TABLE
    "Person/Authorization" ADD CONSTRAINT "person/authorization_autorization_id_foreign" FOREIGN KEY("Autorization_ID") REFERENCES "Authorization"("ID");
ALTER TABLE
    "Person/Department" ADD CONSTRAINT "person/department_department_id_foreign" FOREIGN KEY("Department_ID") REFERENCES "Department"("ID");