CREATE TABLE Customer (
    id integer not null auto_increment PRIMARY KEY,    
    name varchar(200),
    birth datetime    
);

CREATE TABLE Sale (
    id integer not null auto_increment PRIMARY KEY,    
    price integer,
    product varchar(200),
    customerId integer     
);
ALTER TABLE `Sale` ADD CONSTRAINT `fk_customer` FOREIGN KEY ( `customerId` ) REFERENCES `Customer` ( `id` ) ;
