CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    chores(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
        title VARCHAR(50) NOT NULL,
        description VARCHAR(255) NOT NULL,
        completed BOOLEAN NOT NULL DEFAULT false,
        creatorId VARCHAR(255) NOT NULL,
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

INSERT INTO
    chores(
        title,
        description,
        completed,
        creatorId
    )
VALUES (
        'asdfiohoashio',
        "ihfiusdfuds",
        false,
        "63c86f099db0ca50651f0488"
    )