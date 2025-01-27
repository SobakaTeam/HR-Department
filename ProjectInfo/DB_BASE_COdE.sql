CREATE TABLE "Person/Autorization"(
    "id" BIGINT NOT NULL,
    "Person_ID" BIGINT NOT NULL,
    "Autorization_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Person/Autorization" ADD PRIMARY KEY("id");
CREATE TABLE "Person"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NULL,
    "Surname" VARCHAR(255) NULL,
    "MidleNamve" VARCHAR(255) NULL,
    "phone" VARCHAR(255) NULL,
    "Email" VARCHAR(255) NULL,
    "birthday" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL,
    "IsWorking" BOOLEAN NULL,
    "IsMaried" BOOLEAN NULL,
    "NowPlaceLiving" TEXT NULL,
    "HireDate" DATE NULL
);
CREATE INDEX "person_name_surname_index" ON
    "Person"("Name", "Surname");
CREATE INDEX "person_id_index" ON
    "Person"("id");
ALTER TABLE
    "Person" ADD PRIMARY KEY("id");
ALTER TABLE
    "Person" ADD CONSTRAINT "person_email_unique" UNIQUE("Email");
CREATE TABLE "Child"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NULL,
    "Surname" VARCHAR(255) NULL,
    "MidleNamve" VARCHAR(255) NULL,
    "birthday" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
ALTER TABLE
    "Child" ADD PRIMARY KEY("id");
CREATE TABLE "Person/child"(
    "id" BIGINT NOT NULL,
    "Person_ID" BIGINT NOT NULL,
    "Child_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Person/child" ADD PRIMARY KEY("id");
CREATE TABLE "Position"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NOT NULL,
    "Descbigintription" TEXT NULL,
    "CreateAT" DATE NOT NULL,
    "UpdateAtbigint" DATE NULL
);
ALTER TABLE
    "Position" ADD PRIMARY KEY("id");
CREATE TABLE "Person/Position"(
    "id" BIGINT NOT NULL,
    "Person_ID" BIGINT NOT NULL,
    "Position_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Person/Position" ADD PRIMARY KEY("id");
CREATE TABLE "Department"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NOT NULL,
    "Description" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdatbiginteAt" DATE NULL
);
ALTER TABLE
    "Department" ADD PRIMARY KEY("id");
CREATE TABLE "Person/Department"(
    "id" BIGINT NOT NULL,
    "Person_ID" BIGINT NOT NULL,
    "Department_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Person/Department" ADD PRIMARY KEY("id");
CREATE TABLE "Vacation"(
    "id" BIGINT NOT NULL,
    "BeginDate" DATE NOT NULL,
    "EndDate" DATE NULL,
    "Vacation_Type" VARCHAR(255) NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
ALTER TABLE
    "Vacation" ADD PRIMARY KEY("id");
CREATE TABLE "Person/Vacation"(
    "id" BIGINT NOT NULL,
    "Person_ID" BIGINT NOT NULL,
    "Vacation_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Person/Vacation" ADD PRIMARY KEY("id");
CREATE TABLE "Organization"(
    "id" BIGINT NOT NULL,
    "Name" VARCHAR(255) NOT NULL,
    "Registr_Date" DATE NOT NULL,
    "Adress" TEXT NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
ALTER TABLE
    "Organization" ADD PRIMARY KEY("id");
CREATE TABLE "Department/Organization"(
    "id" BIGINT NOT NULL,
    "Department_ID" BIGINT NOT NULL,
    "Organization_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Department/Organization" ADD PRIMARY KEY("id");
CREATE TABLE "Salary"(
    "id" BIGINT NOT NULL,
    "Amount" DECIMAL(8, 2) NOT NULL,
    "Begin_Date" DATE NOT NULL,
    "End_Date" DATE NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAt" DATE NULL
);
ALTER TABLE
    "Salary" ADD PRIMARY KEY("id");
CREATE TABLE "Person/Salary"(
    "id" BIGINT NOT NULL,
    "Person_ID" BIGINT NOT NULL,
    "Salary_ID" BIGINT NOT NULL
);
ALTER TABLE
    "Person/Salary" ADD PRIMARY KEY("id");
CREATE TABLE "Autorization"(
    "id" BIGINT NOT NULL,
    "Login" VARCHAR(255) NOT NULL,
    "Email" BIGINT NULL,
    "Password_Hash" TEXT NOT NULL,
    "Password_Satlt" TEXT NULL,
    "Role" VARCHAR(255) NULL,
    "CreateAt" DATE NOT NULL,
    "UpdateAT" DATE NULL
);
CREATE INDEX "autorization_login_index" ON
    "Autorization"("Login");
CREATE INDEX "autorization_email_index" ON
    "Autorization"("Email");
ALTER TABLE
    "Autorization" ADD PRIMARY KEY("id");
ALTER TABLE
    "Autorization" ADD CONSTRAINT "autorization_login_unique" UNIQUE("Login");
ALTER TABLE
    "Autorization" ADD CONSTRAINT "autorization_email_unique" UNIQUE("Email");
ALTER TABLE
    "Person/Vacation" ADD CONSTRAINT "person/vacation_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("id");
ALTER TABLE
    "Person/Autorization" ADD CONSTRAINT "person/autorization_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("id");
ALTER TABLE
    "Person/child" ADD CONSTRAINT "person/child_child_id_foreign" FOREIGN KEY("Child_ID") REFERENCES "Child"("id");
ALTER TABLE
    "Person/Position" ADD CONSTRAINT "person/position_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("id");
ALTER TABLE
    "Person/child" ADD CONSTRAINT "person/child_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("id");
ALTER TABLE
    "Person/Salary" ADD CONSTRAINT "person/salary_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("id");
ALTER TABLE
    "Person/Position" ADD CONSTRAINT "person/position_position_id_foreign" FOREIGN KEY("Position_ID") REFERENCES "Position"("id");
ALTER TABLE
    "Person/Department" ADD CONSTRAINT "person/department_person_id_foreign" FOREIGN KEY("Person_ID") REFERENCES "Person"("id");
ALTER TABLE
    "Person/Vacation" ADD CONSTRAINT "person/vacation_vacation_id_foreign" FOREIGN KEY("Vacation_ID") REFERENCES "Vacation"("id");
ALTER TABLE
    "Department/Organization" ADD CONSTRAINT "department/organization_department_id_foreign" FOREIGN KEY("Department_ID") REFERENCES "Department"("id");
ALTER TABLE
    "Department/Organization" ADD CONSTRAINT "department/organization_organization_id_foreign" FOREIGN KEY("Organization_ID") REFERENCES "Organization"("id");
ALTER TABLE
    "Person/Salary" ADD CONSTRAINT "person/salary_salary_id_foreign" FOREIGN KEY("Salary_ID") REFERENCES "Salary"("id");
ALTER TABLE
    "Person/Autorization" ADD CONSTRAINT "person/autorization_autorization_id_foreign" FOREIGN KEY("Autorization_ID") REFERENCES "Autorization"("id");
ALTER TABLE
    "Person/Department" ADD CONSTRAINT "person/department_department_id_foreign" FOREIGN KEY("Department_ID") REFERENCES "Department"("id");