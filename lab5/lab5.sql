/*task 3*/
/*1.Add rows to dvd table*/
INSERT INTO dvd (title, production_year) 
VALUES ("The Social Network", 2010);

INSERT INTO dvd (title, production_year) 
VALUES ("The matrix", 1999);

INSERT INTO dvd (title, production_year) 
VALUES ("Shutter Island", 2010);

INSERT INTO dvd (title, production_year) 
VALUES ("Back to the Future", 1985);

INSERT INTO dvd (title, production_year) 
VALUES ("The Town", 2010);

INSERT INTO dvd (title, production_year) 
VALUES ("Another Year", 2010);

/*2.Add rows to customer table*/
INSERT INTO customer (first_name, last_name, password_code, registration_date) 
VALUES ("John", "Smith", "1a2", "2010-06-30");

INSERT INTO customer (first_name, last_name, password_code, registration_date) 
VALUES ("Jane", "Locker", "qwerty123", "2015-10-12");

/*2.Add rows to order table*/
INSERT INTO offer (customer_id, dvd_id, offer_date, return_date) 
VALUES (1, 1, "2012-06-15", "2012-07-01");

INSERT INTO offer (customer_id, dvd_id, offer_date, return_date) 
VALUES (1, 2, "2012-07-02", "2012-07-30");

INSERT INTO offer (customer_id, dvd_id, offer_date, return_date) 
VALUES (2, 2, "2013-01-02", "2013-01-10");

INSERT INTO offer (customer_id, dvd_id, offer_date, return_date) 
VALUES (2, 5, "2020-03-30", "2020-04-30");

INSERT INTO offer (customer_id, dvd_id, offer_date, return_date) 
VALUES (2, 3, "2020-01-30", "2020-06-30");

/*task 4*/
SELECT * FROM dvd
WHERE production_year = 2010 ORDER BY title;

/*task 5*/
SELECT * FROM dvd 
WHERE dvd_id IN (SELECT dvd_id FROM offer WHERE return_date > date('now'));

/*task 6*/
SELECT first_name, last_name, title FROM customer
LEFT OUTER JOIN offer
ON offer.customer_id = customer.customer_id
LEFT OUTER JOIN dvd
ON offer.dvd_id = dvd.dvd_id
WHERE strftime('%Y', offer_date) = strftime('%Y', 'now');




