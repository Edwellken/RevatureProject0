--create table Actor
--(
--Username varchar(20),
--Password varchar(20)
--)

alter table Actor
add Admin bit;

alter table Actor
add ID int identity(1,1) primary key;

--alter table Actor
--add unique (ID);

alter table Actor
drop constraint PK__Actor__3214EC278AE9AFD5;

update Actor
set ID = 0
where ID is null;

alter table Actor
alter column ID int not null;

alter table Actor
add Attempts int default 0 not null;

alter table Actor
add primary key (ID);

alter table Actor
drop column ID;

insert into Actor (Username, Password, Admin)
values ('Edmin', 'apass', 1);

insert into Actor (Username, Password)
values ('Edward', '1234');

select * from Actor;

--create table Accounts
--(
--Id int not null primary key,
--Balance money,
--Active bit,
--ActorID int
--)

alter table Accounts
alter column Balance decimal;

alter table Accounts
drop constraint PK__Accounts__3214EC07228F0933;

alter table Accounts
drop column ID;

alter table Accounts
add ID int identity(1,1) primary key;

insert into Accounts (Balance, Active, ActorID)
values (0, 1, 2)

select * from Accounts
where ActorID = 2;

--create table Deposits
--(
--Id int not null primary key,
--TransactionAmount money,
--TransactionTime datetime,
--AccountID int
--)

alter table Deposits
alter column TransactionAmount decimal;

alter table Deposits
drop constraint PK__Deposits__3214EC077C02E381;

alter table Deposits
drop column ID;

alter table Deposits
add ID int identity(1,1) primary key;

alter table Deposits
drop column TransactionTime;

alter table Deposits
add TransactionTime int identity(1,1);

insert into Deposits (TransactionAmount, AccountID)
values (500.00, 1)

select * from Deposits

--create table Transfers
--(
--Id int not null primary key,
--FromAccountID int,
--ToAccountID int,
--TransferAmount money,
--TransferTime datetime
--)

alter table Transfers
alter column TransferAmount decimal;

alter table Transfers
drop constraint PK__Transfer__3214EC073B07CA72;

alter table Transfers
drop column ID;

alter table Transfers
add ID int identity(1,1) primary key;

