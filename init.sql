-- SQL-скрипт для создания базы данных, таблиц и связей

-- 1. Создание базы данных (если она не существует)
CREATE DATABASE IF NOT EXISTS hr_department_db;

-- 2. Подключение к базе данных
\c hr_department_db;

-- 3. Создание таблицы пользователей (Employee)
CREATE TABLE IF NOT EXISTS employees (
    employee_id SERIAL PRIMARY KEY,       -- Уникальный идентификатор сотрудника
    first_name VARCHAR(100) NOT NULL,     -- Имя сотрудника
    last_name VARCHAR(100) NOT NULL,      -- Фамилия сотрудника
    middle_name VARCHAR(100),          -- Отчество сотрудника
    birthday DATE, -- день рождения
    email VARCHAR(100),   -- Электронная почта 
    phone_number VARCHAR(20),           -- Номер телефона
    hire_date DATE NOT NULL,            -- Дата приема на работу
    position_id INTEGER NOT NULL,             -- Идентификатор должности
    department_id INTEGER NOT NULL,      -- Идентификатор отдела
    manager_id INTEGER,                -- Идентификатор менеджера (руководителя)
    salary DECIMAL(10, 2) NOT NULL,      -- Зарплата
    created_at TIMESTAMP DEFAULT NOW()  -- Дата создания записи
);

-- 4. Создание таблицы продуктов (products)
CREATE TABLE IF NOT EXISTS products (
    product_id SERIAL PRIMARY KEY,    -- Уникальный идентификатор продукта
    name VARCHAR(255) NOT NULL,       -- Название продукта
    description TEXT,                -- Описание продукта
    price DECIMAL(10, 2) NOT NULL,  -- Цена продукта
    stock_quantity INTEGER NOT NULL DEFAULT 0,  -- Количество на складе
    created_at TIMESTAMP DEFAULT NOW()    -- Дата и время создания записи
);

-- 5. Создание таблицы категорий продуктов (categories)
CREATE TABLE IF NOT EXISTS categories (
    category_id SERIAL PRIMARY KEY,  -- Уникальный идентификатор категории
    name VARCHAR(100) NOT NULL UNIQUE, -- Название категории (уникальное)
    description TEXT,                 -- Описание категории
    created_at TIMESTAMP DEFAULT NOW() -- Дата и время создания записи
);

-- 6. Создание связующей таблицы между продуктами и категориями (product_categories)
CREATE TABLE IF NOT EXISTS product_categories (
    product_id INTEGER NOT NULL,
    category_id INTEGER NOT NULL,
    PRIMARY KEY (product_id, category_id),     -- Составной первичный ключ
    FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE CASCADE,  -- Внешний ключ к таблице products
    FOREIGN KEY (category_id) REFERENCES categories(category_id) ON DELETE CASCADE  -- Внешний ключ к таблице categories
);

-- 7. Создание таблицы заказов (orders)
CREATE TABLE IF NOT EXISTS orders (
    order_id SERIAL PRIMARY KEY,   -- Уникальный идентификатор заказа
    user_id INTEGER NOT NULL,   -- Идентификатор пользователя, сделавшего заказ
    order_date TIMESTAMP NOT NULL DEFAULT NOW(),  -- Дата и время заказа
    total_amount DECIMAL(10, 2) NOT NULL,   -- Общая сумма заказа
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE  -- Внешний ключ к таблице users
);

-- 8. Создание таблицы деталей заказа (order_items)
CREATE TABLE IF NOT EXISTS order_items (
    order_item_id SERIAL PRIMARY KEY,   -- Уникальный идентификатор элемента заказа
    order_id INTEGER NOT NULL,        -- Идентификатор заказа
    product_id INTEGER NOT NULL,      -- Идентификатор продукта
    quantity INTEGER NOT NULL,        -- Количество товара
    price DECIMAL(10, 2) NOT NULL,    -- Цена за единицу товара
    FOREIGN KEY (order_id) REFERENCES orders(order_id) ON DELETE CASCADE,     -- Внешний ключ к таблице orders
    FOREIGN KEY (product_id) REFERENCES products(product_id) ON DELETE CASCADE   -- Внешний ключ к таблице products
);

-- 9. Создание таблицы адресов (addresses)
CREATE TABLE IF NOT EXISTS addresses (
    address_id SERIAL PRIMARY KEY,    -- Уникальный идентификатор адреса
    user_id INTEGER NOT NULL,       -- Идентификатор пользователя
    street VARCHAR(255) NOT NULL,     -- Улица
    city VARCHAR(100) NOT NULL,       -- Город
    state VARCHAR(100),              -- Область/штат
    zip_code VARCHAR(20),            -- Почтовый индекс
     FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE -- Внешний ключ к таблице users
);


-- 10. Добавление индексов для таблиц (ускорение поиска)
CREATE INDEX idx_users_username ON users (username);
CREATE INDEX idx_products_name ON products (name);
CREATE INDEX idx_orders_user_id ON orders (user_id);
CREATE INDEX idx_product_categories_product_id ON product_categories (product_id);
CREATE INDEX idx_product_categories_category_id ON product_categories (category_id);


-- 11. Создание пользователя и добавление ему прав
    CREATE USER myuser WITH PASSWORD 'mysecretpassword';
     GRANT ALL PRIVILEGES ON DATABASE my_ecommerce_db TO myuser;