<h1>MyPersonalSpace</h1>

- Auto Mapper

- Asp.Net Core API

- Swagger

- Postman

- Docker

- PostgreSQL

- SMTP Mail Service

- MinIO S3 Cloud Storage servisini

- DBeaver

- API Consume

- Argon2

- Json Web Token

- Login

- Register

- Asp.Net Core 7.0

- Fluent Validation

- N Tier Architecture

- Dto Layer

- MVC

- Entity Framework Core

- Repository Design Pattern

Bu projeyi ASP.NET 7.0, Entity Framework, Katmanlı Mimari, Code-First ve REST API kullanarak geliştirdim. Uygulamanın esnekliğini ve ölçeklenebilirliğini artırmak amacıyla Docker teknolojisinden faydalandım. Veri tabanını bir konteyner içerisinde çalıştırmak için PostgreSQL’in resmi Docker imajını kullanarak, uygulamanın farklı ortamlarda sorunsuz çalışmasını sağladım ve veri tabanı yönetimini daha verimli ve güvenli hale getirdim.

Bununla birlikte, Docker ortamında yeni bir konteyner oluşturarak MinIO S3 Cloud Storage servisini(imajını) kurdum. Kullanıcıların gönderilerinde kullanılan görseller MinIO üzerine yüklenerek güvenli bir şekilde depolanmaktadır.
Frontend tarafında, Bootstrap kütüphanesinin hazır bir temasını kullanarak modern, kullanıcı dostu ve işlevsel bir arayüz tasarladım. Güvenliği sağlamak amacıyla, JWT (JSON Web Token) tabanlı kimlik doğrulama mekanizmasını entegre ettim. Kullanıcı şifrelerinin güvenli bir şekilde saklanması için Argon2 hashing algoritmasını kullanarak, güçlü bir şifreleme altyapısı oluşturulmasını sağladım.

Ayrıca, JWT token’larını istemci tarafında daha güvenli bir şekilde yönetmek amacıyla HttpOnly ve Secure özelliklerine sahip Session Cookie içerisinde tuttum. Böylece, yetkilendirme süreçlerinin güvenliğini artırarak XSS (Cross-Site Scripting) ve Token Hijacking gibi olası güvenlik tehditlerine karşı koruma sağladım. Projeye SMTP (Simple Mail Transfer Protocol) servisini entegre ettim. Bu servis sayesinde, kullanıcılar “Şifremi Unuttum” özelliğini kullanarak kayıtlı e-posta adreslerine şifre sıfırlama bağlantısı alabileceklerdir.

Sıfırlama bağlantısı içerisinde, güvenli bir şekilde oluşturulmuş Password Reset Token yer almakta olup, kullanıcılar bu bağlantı üzerinden yeni bir şifre belirleyerek sisteme giriş yapabileceklerdir. Bu süreç, hem kullanıcı deneyimini iyileştirmekte hem de güvenliği artırarak yetkisiz erişimlerin önüne geçilmesini sağlamaktadır.

Bu proje için, SAGA üzerinden Linux tabanlı bir sanal sunucu satın alarak sunucu altyapısını oluşturdum. Sunucu içerisine Ubuntu işletim sistemini kurarak, uygulamamın güvenli ve kararlı bir şekilde çalışmasını sağladım. Ayrıca, Ubuntu işletim sistemine Docker kurarak, sanal bir ortamda Docker ile uygulama dağıtımı yapmayı öğrendim. Geliştirdiğim projeyi bu sanal sunucuya taşıyarak, herkesin erişebileceği bir ortam oluşturup, uygulamanın internet üzerinden yayınlanmasını sağladım. Bu yapı, uygulamanın erişilebilirliğini artırırken, bağımsız ve ölçeklenebilir bir sunucu ortamı sunarak kesintisiz hizmet vermesine olanak tanımaktadır.

<img width="872" alt="1" src="https://github.com/user-attachments/assets/17e7d15c-81e2-42a4-abbf-e8a2dbf4d244" />

<img width="872" alt="2" src="https://github.com/user-attachments/assets/4e09779e-4c8c-4659-9da5-f291f59ffae2" />

<img width="872" alt="3" src="https://github.com/user-attachments/assets/2fd15923-e026-4bc4-a0dd-a16be6d58acc" />

<img width="733" alt="4(önce)" src="https://github.com/user-attachments/assets/af5d34fc-b7fb-4d14-8664-88bb64067392" />

<img width="1438" alt="4" src="https://github.com/user-attachments/assets/c277edbd-e10d-4427-9b6d-20a49281b92d" />

<img width="1438" alt="5" src="https://github.com/user-attachments/assets/575c5fac-b1e1-40e4-86e0-92e7d2219022" />

<img width="1438" alt="6" src="https://github.com/user-attachments/assets/202be6b2-7f40-4cff-a754-7e35246ede72" />

<img width="1438" alt="7" src="https://github.com/user-attachments/assets/04712820-6e30-40aa-8b26-a8dce994c7aa" />

<img width="1438" alt="8" src="https://github.com/user-attachments/assets/7928b9c1-9a8b-49e6-aeeb-d9821738e0d9" />

<img width="1438" alt="9" src="https://github.com/user-attachments/assets/85a681ee-f134-47d6-9b99-2e17b645aebc" />

<img width="1438" alt="10" src="https://github.com/user-attachments/assets/2953b803-d639-437e-9f19-188965696fe5" />

<img width="1438" alt="11" src="https://github.com/user-attachments/assets/4e0aebe8-d027-463f-a52e-a1e2b0ded76d" />

<img width="1438" alt="12" src="https://github.com/user-attachments/assets/a2d4008b-9913-468f-b187-adae73171ce1" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 03 39" src="https://github.com/user-attachments/assets/5432a50c-c6c5-4335-ba70-1bcc776cc292" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 03 46" src="https://github.com/user-attachments/assets/45a3a0b0-2b8a-462b-a295-2f771b1bbf75" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 04 00" src="https://github.com/user-attachments/assets/06cd659a-a438-454a-ae22-da47fa542791" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 07 03" src="https://github.com/user-attachments/assets/b7a92545-107a-41e9-9d9f-527af0fb3a0e" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 07 28" src="https://github.com/user-attachments/assets/5ec46675-8cf4-4b14-86aa-6f3f17349a70" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 00 10" src="https://github.com/user-attachments/assets/cb18ef8d-53f2-4a91-b1f6-8d64b66e6e25" />

<img width="1438" alt="Ekran Resmi 2025-03-10 20 59 33" src="https://github.com/user-attachments/assets/4c5c3023-fe04-48aa-af0f-f42f526e3e09" />

<img width="1438" alt="Ekran Resmi 2025-03-10 21 05 37" src="https://github.com/user-attachments/assets/93387e2d-5954-4f62-8b93-0a5a4ad6c371" />









