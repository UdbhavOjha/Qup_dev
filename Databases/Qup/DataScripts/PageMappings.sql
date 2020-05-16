
-- insert pages for end client 
 insert into dbo.platformpages
 values ('/Clients/PatronDashboard.aspx')
 
insert into dbo.usergroupstopages
values (1, 1) -- usergroupid, pageid
 
-- insert pages for manager 
 insert into dbo.platformpages 
 values ('/Manager/Dashboard.aspx'),
 ('/Manager/SearchHistory.aspx')

insert into dbo.usergroupstopages
values (2, 2) -- usergroupid, pageid

insert into dbo.usergroupstopages
values (2, 3) -- usergroupid, pageid

-- insert pages for super admins
 insert into dbo.platformpages 
 values ('/Admins/AdminDashboard.aspx'),
  ('/Admins/CreateNewUser.aspx'),
  ('/Admins/NewBusinessOnboard.aspx')
  
 insert into dbo.usergroupstopages 
 values (3, 4), (3, 5), (3, 6)

-- general ('/Logout.aspx')
 insert into dbo.platformpages
 values ('/Login.aspx')
 
 insert into dbo.platformpages
 values ('/Logout.aspx')
 
insert into dbo.usergroupstopages 
values (1, 8), (2, 8), (3, 8)
