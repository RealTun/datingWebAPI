create database Dating;

use Dating;

CREATE TABLE [user_account] (
	[id] int IDENTITY(1,1) PRIMARY KEY, 
	[email] nvarchar(100) UNIQUE, 
	[phone] nvarchar(20) UNIQUE, 
	[password] nvarchar(256) NOT NULL, 
	[name] nvarchar(100) NOT NULL, 
	[bio] text NULL, 
	[age] int, 
	[gender] tinyint, 
	[looking_for] tinyint,
	[location] nvarchar(50),
	[confirmation_code] char(4) NOT NULL, 
	[confirmation_time] datetime NULL
);


-- insert fake data
--DECLARE @i int = 0;

--WHILE @i < 20
--BEGIN
--  INSERT INTO user_account (email, phone, password, name, bio, age, gender, looking_for, location, confirmation_code, confirmation_time)
--  VALUES (
--    'user' + CAST(@i AS nvarchar(3)) + '@example.com',  -- Generate email with user+id@example.com
--    '0123' + CAST(@i * 1000 AS nvarchar(10)),  -- Generate phone with 0123+id*1000
--    'password' + CAST(@i AS nvarchar(3)),  -- Sample password (replace with hashing logic)
--    'Name' + CAST(@i AS nvarchar(3)),  -- Generate name with Name+id
--    'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', -- Sample bio
--    FLOOR(RAND() * (45 - 18 + 1)) + 18,  -- Generate random age between 18 and 45
--    CAST(FLOOR(RAND() * 2) AS tinyint), -- Generate random gender (0 or 1)
--    CAST(FLOOR(RAND() * 2) AS tinyint), -- Generate random looking_for (0 or 1)
--    'City' + CAST(@i AS nvarchar(2)),  -- Generate location with City+id
--    CAST(FLOOR(RAND() * 9000 + 1000) AS char(4)), -- Generate random confirmation code
--    NULL  -- confirmation_time initially null
--  );

--  SET @i = @i + 1;
--END;

CREATE TABLE [user_photo] (
	[id] int IDENTITY(1,1) PRIMARY KEY, 
	[user_account_id] int not null, 
	[link] varchar(256)
	foreign key (user_account_id) references user_account(id)
);


CREATE TABLE [relationship_type] (
	[id] int IDENTITY(1,1) PRIMARY KEY, 
	[name] nvarchar(100) UNIQUE
);

--insert into [relationship_type] ([name]) values 
--(N'Người yêu'), (N'Những người bạn mới'),
--(N'Bất kì điều gì có thể'), (N'Mình cũng chưa rõ lắm')


CREATE TABLE [interested_in_relation] (
	[id] int IDENTITY(1,1) PRIMARY KEY, 
	[user_account_id] int not null, 
	[relationship_type_id] int not null,
	foreign key (user_account_id) references user_account(id),
	foreign key (relationship_type_id) references relationship_type(id)
);


CREATE TABLE [interest_type] (
	[id] int IDENTITY(1,1) PRIMARY KEY, 
	[name] nvarchar(100) UNIQUE
);

INSERT INTO interest_type ([name]) VALUES
(N'Thể thao'),(N'Âm nhạc'),(N'Điện ảnh'),(N'Đọc sách'),(N'Chơi game'),(N'Du lịch'),(N'Ẩm thực'),(N'Vẽ tranh'),
(N'Chụp ảnh'),(N'Làm vườn'),(N'Nuôi thú cưng'),(N'May vá'),(N'Đan móc'),('Origami'),(N'Thủ công'),
(N'Bộ sưu tập'),(N'Cờ bạc'),(N'Khiêu vũ'),(N'Nghệ thuật'),(N'Lịch sử'),(N'Khoa học'),
(N'Bóng đá'),(N'Bóng rổ'),(N'Bóng chuyền'),(N'Cầu lông'),('Tennis'),(N'Bơi lội'),(N'Chạy bộ'),('Gym'),('Yoga')


CREATE TABLE [interest_user] (
  [id] int IDENTITY(1,1) PRIMARY KEY, 
  [interest_type_id] int not null,
  [user_account_id] int not null,
  foreign key (user_account_id) references user_account(id),
  foreign key (interest_type_id) references interest_type(id)
);



CREATE TABLE [match] (
  [id] int IDENTITY(1,1) PRIMARY KEY, 
  [user1_id] int not null,
  [user2_id] int not null,
  [match_date] datetime,
  foreign key ([user1_id]) references user_account(id),
  foreign key ([user2_id]) references user_account(id)
);


CREATE TABLE [message] (
  [id] int IDENTITY(1,1) PRIMARY KEY, 
  [match_id] int not null,
  [sender_id] int not null,
  [receiver_id] int not null,
  [message_content] text not null,
  [time_sent] datetime not null,
  foreign key (match_id) references [match](id),
  foreign key (sender_id) references user_account(id),
  foreign key (receiver_id) references user_account(id)
);



CREATE TABLE [preference] (
  [id] int IDENTITY(1,1) PRIMARY KEY, 
  [user_account_id] int not null,
  [min_age] int not null,
  [max_age] int not null,
  [max_distance] int not null,
  foreign key (user_account_id) references user_account(id)
);


CREATE TABLE [block_user] (
  [id] int IDENTITY(1,1) PRIMARY KEY, 
  [user_account_id] int not null,
  [user_account_id_blocked] int not null,
  foreign key (user_account_id) references user_account(id),
  foreign key (user_account_id_blocked) references user_account(id)
);
