use master
CREATE database dannys_diner;
GO
use dannys_diner
go

CREATE TABLE menu (
  "product_id" INTEGER primary key,
  "product_name" VARCHAR(5),
  "price" INTEGER
);

INSERT INTO menu
  ("product_id", "product_name", "price")
VALUES
  ('1', 'sushi', '10'),
  ('2', 'curry', '15'),
  ('3', 'ramen', '12');
  

CREATE TABLE members (
  "customer_id" VARCHAR(1) primary key,
  "join_date" DATE
);

INSERT INTO members
  ("customer_id", "join_date")
VALUES
  ('A', '2021-01-07'),
  ('B', '2021-01-09'),
  ('C','2021-01-05');
  CREATE TABLE sales (
  "sale_id" varchar(2) primary key,
  "customer_id" VARCHAR(1),
  "order_date" DATE,
  "product_id" INTEGER,
  constraint fk_key_customer foreign key (customer_id) references members (customer_id),
  constraint fk_key_product foreign key (product_id) references menu (product_id)
);

INSERT INTO sales
  ( "sale_id","customer_id", "order_date", "product_id")
VALUES
  ('1','A', '2021-01-01', '1'),
  ('2','A', '2021-01-01', '2'),
  ('3','A', '2021-01-07', '2'),
  ('4','A', '2021-01-10', '3'),
  ('5','A', '2021-01-11', '3'),
  ('6','A', '2021-01-11', '3'),
  ('7','B', '2021-01-01', '2'),
  ('8','B', '2021-01-02', '2'),
  ('9','B', '2021-01-04', '1'),
  ('10','B', '2021-01-11', '1'),
  ('11','B', '2021-01-16', '3'),
  ('12','B', '2021-02-01', '3'),
  ('13','C', '2021-01-01', '3'),
  ('14','C', '2021-01-01', '3'),
  ('15','C', '2021-01-07', '3');
  ----1----
	  SELECT 
	  customer_id, 
	  SUM(price) AS total_sales
	  FROM sales
	  INNER JOIN menu ON sales.product_id = menu.product_id
	  GROUP BY sales.customer_id
	  ORDER BY sales.customer_id ASC; 
  ----2----
	select customer_id, count(distinct order_date) as visit 
	from sales
	group by customer_id
  ----3----
	