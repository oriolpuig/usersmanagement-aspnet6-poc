# Users management PoC

### Steps to launch

* Open the .sln file with Visual Studio (developed with 2019 version)
* Execute migrations before launch application.
* Launch the application: A login page should be displayed. 

### How to use the application
The application has two ways to be used; as an MVC application or as an API.

#### MVC application
* You can login with provided default credentials.
* Each view should be accessed by the defined role. If you don't have access, you will be redirected to Login page.

#### API
* You should have access to a Users CRUD with Postman (per example)
* Every endpoints is secured by Basic Authentication. Only allowed Admin role users.
* List of exposed endpoints: 

```
GET     /api/users
GET     /api/users/:id
POST    /api/users
PUT     /api/users/:id
DELETE  /api/users/:id
```

### Credentials
| Username | Password |
|:--------:|:--------:|
| Admin    | Admin    |
| PAGE_1   | PAGE_1   |
| PAGE_2   | PAGE_2   |
| PAGE_3   | PAGE_3   |
