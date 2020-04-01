-- NOTE Libraries
-- CREATE TABLE libraries (
--     id INT NOT NULL AUTO_INCREMENT,
--     name VARCHAR(255) NOT NULL,
--     PRIMARY KEY(ID)
-- )

--NOTE Books
-- CREATE TABLE books (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     description VARCHAR(255),
--     pages INT NOT NULL, 
--     isAvailable TINYINT,

--     PRIMARY KEY (id)
-- )

--NOTE Bookers
-- CREATE TABLE bookers (
--     id INT NOT NULL AUTO_INCREMENT,
--     title VARCHAR(255) NOT NULL,
--     pages INT NOT NULL,
--     isAvailable TINYINT,
--     lbId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (lbId)
--         REFERENCES libraries(id)
--         ON DELETE CASCADE
-- )


-- --NOTE Authors
-- CREATE TABLE authors (
--     id INT 
-- )


--NOTE bookAuthors
-- CREATE TABLE bookAuthors (
--     id INT NOT NULL AUTO_INCREMENT,
--     lbId INT NOT NULL,
--     atId INT NOT NULL,
--     PRIMARY KEY (id),

--     FOREIGN KEY (lbId)
--         REFERENCES libraries(id)
--         ON DELETE CASCADE
    
--     FOREIGN KEY (atId)
--         REFERENCES authors(id)
--         ON DELETE CASCADE
-- )
