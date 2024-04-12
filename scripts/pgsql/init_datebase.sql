-- 若toyar数据库存在则删除
drop database if EXISTS toyar;

create database toyar with encoding 'UTF8' template=template0;