-- initialize db 
create database airfryer;
create user airfryer with encrypted password '';
grant all privileges on airfryer to airfryer;
grant all on schema public to airfryer;