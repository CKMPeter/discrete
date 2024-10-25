CREATE TABLE Person (
    name CHAR(100),  
    birthDate DATE,
    partner CHAR(100),
    PRIMARY KEY(name, birthDate)
);