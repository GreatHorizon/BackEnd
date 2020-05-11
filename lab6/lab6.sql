/*1. (#15)  Напишите SQL запросы  для решения задач ниже.*/
CREATE TABLE "PC" (
	"id_pc"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"cpu(MHz)"	INTEGER NOT NULL,
	"memory(Mb)"	INTEGER NOT NULL,
	"hdd(Gb)"	INTEGER NOT NULL
);

INSERT INTO 
PC("cpu(MHz)", "memory(Mb)",  "hdd(Gb)") VALUES	
(1600, 2000, 500),
(2400, 3000, 800),
(3200, 3000, 1200),
(2400, 2000, 500);

/* 1) Тактовые частоты CPU тех компьютеров, 
у которых объем памяти 3000 Мб. Вывод: id, cpu, memory*/
SELECT id_pc, "cpu(MHz)", "memory(Mb)"
FROM PC
WHERE "memory(Mb)" = 3000;

/* 2) Минимальный объём жесткого диска, 
установленного в компьютере на складе. Вывод: hdd*/
SELECT MIN("hdd(Gb)") AS min_hdd
FROM PC;

/* 3) Количество компьютеров с минимальным объемом жесткого диска,
 доступного на складе. Вывод: count, hdd*/
SELECT "hdd(Gb)" AS hdd, COUNT("hdd(Gb)") AS "count" 
FROM PC
WHERE "hdd(Gb)" IN (SELECT MIN("hdd(Gb)") FROM PC);


/*2. (#30) Напишите SQL-запрос, возвращающий все пары (download_count, user_count), 
	удовлетворяющие следующему условию: 
	user_count — общее ненулевое число пользователей, сделавших 
    ровно download_count скачиваний 19 ноября 2010 года.*/

CREATE TABLE track_downloads ( 
	download_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
    track_id INTEGER NOT NULL, 
    user_id INTEGER NOT NULL, 
    download_time TEXT NOT NULL    
); 

INSERT INTO track_downloads(track_id, user_id, download_time)
VALUES 
	(1, 2 ,'2010-11-19'),
	(6, 2 ,'2010-11-19'),
	(7, 2 ,'2010-11-19'),
	(9, 2 ,'2010-11-19'),
	(1, 3 ,'2010-11-19'),
	(2, 1 ,'2010-11-19'),
	(9, 1 ,'2010-11-19'),
	(7, 1 ,'2010-11-19'),
	(9, 4 ,'2010-11-19'),
	(9, 5 ,'2010-11-19');
	
SELECT download_count, count(download_count) AS user_count 
FROM 
(
	SELECT count(user_id) AS download_count 
	FROM track_downloads
	WHERE download_time='2010-11-19'
	GROUP BY user_id 
)
GROUP BY download_count;
	
/*3. (#10) Опишите разницу типов данных DATETIME и TIMESTAMP*/
/*DATATIME
Хранит время в виде целого числа в формате YYYYMMDDHHMMSS, не зависит от временной зоны.
Хранит 8 байт.
TIMESTAMP
Хранит время как число равное количеству секунд прошедших с полуночи 1 января 1970 года
(нулевой часовой пояс). При получении из базы отображатеся с учетом временной зоны.
Хранит 4 байта.
*/

/*4.(#20)  Необходимо создать таблицу студентов (поля id, name) и таблицу курсов (поля id, name).
 Каждый студент может посещать несколько курсов. Названия курсов и имена студентов - произвольны.*/

CREATE TABLE "student" (
	"student_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"name"	TEXT NOT NULL
);

CREATE TABLE "course" (
	"course_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"name"	TEXT NOT NULL
);

CREATE TABLE "student_on_course" (
	"student_id"	INTEGER NOT NULL,
	"course_id"	INTEGER NOT NULL,
	FOREIGN KEY("student_id") REFERENCES "student"("student_id"),
	FOREIGN KEY("course_id") REFERENCES "course"("course_id")
);

INSERT INTO student(name)
VALUES 
	('Viktor Jan'),
	('Ivan Andreev'),
	('Linda James'),
	('Viktoria Jan'),
	('Denis Mehov'),
	('Carl Smith');
	
INSERT INTO course(name)
VALUES
	('Math'),
	('Biology'),
	('Programming'),
	('Physics');
	
INSERT INTO student_on_course(student_id, course_id)
VALUES
	(1, 1),
	(1, 2),
	(2, 2),
	(3, 2),
	(4, 2),
	(5, 2),
	(6, 2),
	(6, 3);

/* 1. отобразить количество курсов, на которые ходит более 5 студентов*/
SELECT count(*) as quantity_of_courses FROM
(
	SELECT count(*)
	FROM student_on_course
	GROUP BY course_id
	HAVING count(*) > 5
);

/* 2. отобразить все курсы, на которые записан определенный студент.*/
SELECT course.name FROM student
LEFT OUTER JOIN student_on_course
ON student.student_id = student_on_course.student_id
LEFT OUTER JOIN course
ON course.course_id = student_on_course.course_id
WHERE student.name = 'Carl Smith';


/*5. (5#) Может ли значение в столбце(ах), на который наложено 
ограничение foreign key, равняться null? Привидите пример. */

/*Да, может быть равно NULL, если на него не будет ограничения NOT NULL*/
/*Например:*/
CREATE TABLE "customers" (
	"customer_id" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"name" TEXt NOT NULL
);

CREATE TABLE "booking" (
	"booking_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"price"	INTEGER NOT NULL,
	"customer_id" INTEGER,
	FOREIGN KEY("customer_id") REFERENCES "customers"("customer_id")
);

INSERT INTO customers(name)
VALUES 
	('Dima'),
	('Katya'),
	('Tanya');
	
INSERT INTO booking(price, customer_id)
VALUES 
	(1300, 2),
	(900, NULL),
	(10000, 3);


/*6. (#15) Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
Приведите пример таблиц с данными и запросы. */

CREATE TABLE "tire" (
	"tire_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"brand"	INTEGER NOT NULL,
	"cost"	INTEGER NOT NULL
);

INSERT INTO tire(brand, cost)
VALUES
	('Nokian', 150),
	('Nokian', 200),
	('Goodyear', 70),
	('Bridgestone', 120);
	
SELECT DISTINCT brand FROM tire;
/*Output : 
1. Nokian
2. Goodyear
3. Bridgestone
*/
/*При добавлении cost в select в данном случае получим все 4 строки
, т.к проверять уникальность будет уже по 2 столбцам */
SELECT DISTINCT brand, cost FROM tire;
/*Output : 
1. Nokian 150
2. Nokian 200
3. Goodyear 70
4. Bridgestone 120
*/


/*7. (#10) Есть две таблицы:
     users - таблица с пользователями (users_id, name)
    orders - таблица с заказами (orders_id, users_id, status)
    1) Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0
    2) Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1
*/
CREATE TABLE "users" (
	"user_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"name"	INTEGER NOT NULL
);

CREATE TABLE "orders" (
	"orders_id"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"status"	INTEGER NOT NULL,
	"users_id"	INTEGER NOT NULL,
	FOREIGN KEY("users_id") REFERENCES "users"("users_id")
);

INSERT INTO users(name)
VALUES 
	('Viktor Jan'),
	('Ivan Andreev'),
	('Linda James'),
	('Viktoria Jan'),
	('Denis Mehov'),
	('Carl Smith');

INSERT INTO orders(users_id, status)
VALUES 
	(3, 0),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(2, 0),
	(2, 0),
	(2, 0),
	(5, 0);

/* 1) Выбрать всех пользователей из таблицы users, 
у которых ВСЕ записи в таблице orders имеют status = 0*/
SELECT * FROM users
WHERE users_id IN
(	SELECT users_id FROM orders WHERE 
	status = 0 AND users_id NOT IN 
	(
		SELECT users_id FROM orders
		WHERE status != 0
	)
);

/*2) Выбрать всех пользователей из таблицы users, у которых 
больше 5 записей в таблице orders имеют status = 1*/
SELECT * FROM users
WHERE users_id IN
(
	SELECT users_id FROM orders
	WHERE status = 1
	GROUP BY users_id
	HAVING count(users_id) > 5
);


/*8. (#10)  В чем различие между выражениями HAVING и WHERE?*/

/*WHERE выполняется до получения результата, 
ограничивает не подходщие по условию во время запросы.
Проверяемое условие может содержать 
агрегатную функцию(min(), sum() и тд) только внутри подзапроса.

HAVING же фильтрует результат операции, убирая неподходящие значения
после получения результата.
Можно использовать с агрегатными функциями напрямую.*/

