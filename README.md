<h1>MyPersonalSpace</h1>

— Auto Mapper

— Asp.Net Core API

— Swagger

— Postman

— Docker

— PostgreSQL

— SMTP Mail Service

— MinIO S3 Cloud Storage servisini

— DBeaver

— API Consume

— Json Web Token

— Login

— Register

— Asp.Net Core 7.0

— Fluent Validation

— N Tier Architecture

— Dto Layer

— MVC

— Entity Framework Core

— Repository Design Pattern


Bu projeyi ASP.NET 7.0, Entity Framework, Katmanlı Mimari, Code-First ve REST API kullanarak geliştirdim. Uygulamanın esnekliğini ve ölçeklenebilirliğini artırmak amacıyla Docker teknolojisinden faydalandım. Veri tabanını bir konteyner içerisinde çalıştırmak için PostgreSQL’in resmi Docker imajını kullanarak, uygulamanın farklı ortamlarda sorunsuz çalışmasını sağladım ve veri tabanı yönetimini daha verimli ve güvenli hale getirdim.

Bununla birlikte, Docker ortamında yeni bir konteyner oluşturarak MinIO S3 Cloud Storage servisini(imajını) kurdum. Kullanıcıların gönderilerinde kullanılan görseller MinIO üzerine yüklenerek güvenli bir şekilde depolanmaktadır.

Frontend tarafında, Bootstrap kütüphanesinin hazır bir temasını kullanarak modern, kullanıcı dostu ve işlevsel bir arayüz tasarladım.
Güvenliği sağlamak amacıyla, JWT (JSON Web Token) tabanlı kimlik doğrulama mekanizmasını entegre ettim. Kullanıcı şifrelerinin güvenli bir şekilde saklanması için Argon2 hashing algoritmasını kullanarak, güçlü bir şifreleme altyapısı oluşturulmasını sağladım.

Ayrıca, JWT token’larını istemci tarafında daha güvenli bir şekilde yönetmek amacıyla HttpOnly ve Secure özelliklerine sahip Session Cookie içerisinde tuttum. Böylece, yetkilendirme süreçlerinin güvenliğini artırarak XSS (Cross-Site Scripting) ve Token Hijacking gibi olası güvenlik tehditlerine karşı koruma sağladım.
Projeye SMTP (Simple Mail Transfer Protocol) servisini entegre ettim. Bu servis sayesinde, kullanıcılar “Şifremi Unuttum” özelliğini kullanarak kayıtlı e-posta adreslerine şifre sıfırlama bağlantısı alabileceklerdir.

Sıfırlama bağlantısı içerisinde, güvenli bir şekilde oluşturulmuş Password Reset Token yer almakta olup, kullanıcılar bu bağlantı üzerinden yeni bir şifre belirleyerek sisteme giriş yapabileceklerdir. Bu süreç, hem kullanıcı deneyimini iyileştirmekte hem de güvenliği artırarak yetkisiz erişimlerin önüne geçilmesini sağlamaktadır.

Bu proje için, SAGA üzerinden Linux tabanlı bir sanal sunucu satın alarak sunucu altyapısını oluşturdum. Sunucu içerisine Ubuntu işletim sistemini kurarak, uygulamamın güvenli ve kararlı bir şekilde çalışmasını sağladım. Ayrıca, Ubuntu işletim sistemine Docker kurarak, sanal bir ortamda Docker ile uygulama dağıtımı yapmayı öğrendim. Geliştirdiğim projeyi bu sanal sunucuya taşıyarak, herkesin erişebileceği bir ortam oluşturup, uygulamanın internet üzerinden yayınlanmasını sağladım. Bu yapı, uygulamanın erişilebilirliğini artırırken, bağımsız ve ölçeklenebilir bir sunucu ortamı sunarak kesintisiz hizmet vermesine olanak tanımaktadır.

<img width="1435" alt="Ekran Resmi 2025-03-01 02 48 58" src="https://github.com/user-attachments/assets/06c518de-6a0f-4c40-bcca-d3a6ec37de0d" />

<img width="1435" alt="Ekran Resmi 2025-03-01 02 49 09" src="https://github.com/user-attachments/assets/306da41a-c07a-4500-9b70-ccc86ccf898a" />

<img width="1435" alt="Ekran Resmi 2025-03-01 02 49 36" src="https://github.com/user-attachments/assets/4af7de5d-b4d0-43d7-8085-40241e4080e1" />

<img width="736" alt="Ekran Resmi 2025-03-01 02 51 34" src="https://github.com/user-attachments/assets/98361a05-91bc-47e5-bc06-7a387d950c4c" />

<img width="1437" alt="Ekran Resmi 2025-03-01 02 53 36" src="https://github.com/user-attachments/assets/40f7db6f-618c-4366-96f2-50faad1380e1" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 54 03" src="https://github.com/user-attachments/assets/fe5c9e08-f0ca-42da-980c-940184b92974" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 54 11" src="https://github.com/user-attachments/assets/4d9ffd0c-ea76-459c-8ae7-4960119a6899" />

<img width="1437" alt="Ekran Resmi 2025-03-01 02 54 17" src="https://github.com/user-attachments/assets/66f738c7-e4f8-46d1-a134-6ecc71fb7555" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 54 24" src="https://github.com/user-attachments/assets/f728bd41-b59b-47f6-9d5d-785b0c4f8292" />

<img width="1437" alt="Ekran Resmi 2025-03-01 02 57 05" src="https://github.com/user-attachments/assets/9064e45a-c2a8-4174-8198-ddcfc94d85ce" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 57 14" src="https://github.com/user-attachments/assets/cf4de8b4-10ee-4e0b-b237-5b40cebcb96d" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 57 25" src="https://github.com/user-attachments/assets/f3a5c1be-9429-4d9d-b96c-de7786579fcf" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 58 01" src="https://github.com/user-attachments/assets/6c6572bd-1a22-4509-ac59-6631276eb894" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 57 34" src="https://github.com/user-attachments/assets/8082edc4-b9a0-4d65-910e-27223d517e4f" />

<img width="1437" alt="Ekran Resmi 2025-03-01 02 57 45" src="https://github.com/user-attachments/assets/f5f79daf-38ef-415b-ad72-1cb413ef51b5" />


<img width="1437" alt="Ekran Resmi 2025-03-01 02 57 45" src="https://github.com/user-attachments/assets/573b3cb0-73db-480c-9861-285d8ced1638" />

<img width="1431" alt="Ekran Resmi 2025-03-01 20 43 35" src="https://github.com/user-attachments/assets/2739dba6-ec90-4d77-82a0-8e1bbd4c5cb0" />







