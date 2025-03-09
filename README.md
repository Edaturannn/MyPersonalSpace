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
Frontend tarafında, Bootstrap kütüphanesinin hazır bir temasını kullanarak modern, kullanıcı dostu ve işlevsel bir arayüz tasarladım. Güvenliği sağlamak amacıyla, JWT (JSON Web Token) tabanlı kimlik doğrulama mekanizmasını entegre ettim. Kullanıcı şifrelerinin güvenli bir şekilde saklanması için Argon2 hashing algoritmasını kullanarak, güçlü bir şifreleme altyapısı oluşturulmasını sağladım.

Ayrıca, JWT token’larını istemci tarafında daha güvenli bir şekilde yönetmek amacıyla HttpOnly ve Secure özelliklerine sahip Session Cookie içerisinde tuttum. Böylece, yetkilendirme süreçlerinin güvenliğini artırarak XSS (Cross-Site Scripting) ve Token Hijacking gibi olası güvenlik tehditlerine karşı koruma sağladım. Projeye SMTP (Simple Mail Transfer Protocol) servisini entegre ettim. Bu servis sayesinde, kullanıcılar “Şifremi Unuttum” özelliğini kullanarak kayıtlı e-posta adreslerine şifre sıfırlama bağlantısı alabileceklerdir.

Sıfırlama bağlantısı içerisinde, güvenli bir şekilde oluşturulmuş Password Reset Token yer almakta olup, kullanıcılar bu bağlantı üzerinden yeni bir şifre belirleyerek sisteme giriş yapabileceklerdir. Bu süreç, hem kullanıcı deneyimini iyileştirmekte hem de güvenliği artırarak yetkisiz erişimlerin önüne geçilmesini sağlamaktadır.

Bu proje için, SAGA üzerinden Linux tabanlı bir sanal sunucu satın alarak sunucu altyapısını oluşturdum. Sunucu içerisine Ubuntu işletim sistemini kurarak, uygulamamın güvenli ve kararlı bir şekilde çalışmasını sağladım. Ayrıca, Ubuntu işletim sistemine Docker kurarak, sanal bir ortamda Docker ile uygulama dağıtımı yapmayı öğrendim. Geliştirdiğim projeyi bu sanal sunucuya taşıyarak, herkesin erişebileceği bir ortam oluşturup, uygulamanın internet üzerinden yayınlanmasını sağladım. Bu yapı, uygulamanın erişilebilirliğini artırırken, bağımsız ve ölçeklenebilir bir sunucu ortamı sunarak kesintisiz hizmet vermesine olanak tanımaktadır.
