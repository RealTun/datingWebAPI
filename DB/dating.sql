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
