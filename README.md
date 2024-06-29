Customer Feedback System

Develop aplikasi Console dan Website untuk melakukan feedback dari customer (Console), kemudian pada websitenya manager dapat melakukan review terhadap feedback yang dimasukkan oleh custemer. Selain itu pada website juga terdapat categorize feedback customer berdasrkan feedback yang belum direview dan yang sudah direview yang dipisiahkan oleh masing-masing tabel. Untuk databasenya terdapat 2 tabel yaitu Customers dan Feedbacks. Untuk detailnya seperti ini:

- Customers
CustomerID (Primary Key),
Name,
Email,

- Feedback
FeedbackID (Primary Key),
CustomerID (Foreign Key),
FeedbackText,
Status (Pending, Reviewed),
