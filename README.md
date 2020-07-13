# InvEtradeRepo
Hello,

This is an asp.net mvc project which has etrade samples. 

The project contains repository pattern, service layers, dependency injection (via unity), poco classes, Identity Framework for Admin panel,admin panel site, web panel site.

To run this project you need to set up a database which is name "InveonDB", run Inveon.Db.sql file at same directory path with readme.txt, then run below command to create tables with some sample data.

Scaffold-DbContext 'Data Source=localhost;Initial Catalog=InveonDB; User ID=sa;Password=xxxxxx; Connection Timeout=240;MultipleActiveResultSets=True;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir "DummyEntity" -Force -Context 'InveonContext'

sample username and password are efecetir@gmail.com, 123456

You can register with any password and mail address from register side. When you register you will be an admin login.

you can add products and images from product menu.

After you add the products you can view the products from Inveon.Web project. 

Hint: To view product images your admin project must work. Because I'm storing the pictures at this project. 
	  Don't forget set web.config connection strings according to your database login informations.

please don't hesitate to ask me any question about project and framework. My email address is : efecetir@gmail.com

Efecan Cetir
