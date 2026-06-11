
📰 News API


News API, istifadəçilərin ən son xəbərləri, önə çıxan məqalələri və son dəqiqə hadisələrini oxuya bilməsi üçün hazırlanmış, sürətli və təhlükəsiz bir RESTful API xidmətidir. Bu layihə front-end tətbiqlərinin xəbər məlumatları ilə təmin edilməsinə köklənib və istifadəçilərin həm ana səhifədə, həm də detallı səhifələrdə xəbərləri görməsinə şərait yaradır.

🛠 Texnologiyalar
Framework: .NET 8 Web API

ORM: Entity Framework Core

Verilənlər Bazası: Microsoft SQL Server (MSSQL)

Dokumentasiya: Swagger / OpenAPI

⚙️ Tələblər
Layihəni öz kompüterinizdə işə salmaq üçün aşağıdakılar quraşdırılmalıdır:

.NET 8.0 SDK

Microsoft SQL Server

EntityFramework

🚀 Quraşdırma Təlimatı
Layihəni lokal mühitdə problemsiz işə salmaq üçün aşağıdakı addımları ardıcıl izləyin.

Repozitoriyanı klonlayın:
git clone https://github.com/mqulamhuseynov/NewsApi
cd NewsAPI

Asılılıqları (Dependencies) yükləyin:
dotnet restore

Mühit (Environment) Dəyişənlərini təyin edin:
Layihənin ana qovluğunda .env adlı yeni bir fayl yaradın və aşağıdakı açarları əlavə edin. Dəyərləri öz lokal mühitinizə uyğun olaraq doldurun:

DATABASE=
CORS=

Verilənlər Bazasını miqrasiya edin (Migrations):
dotnet ef database update

Layihəni işə salın:
dotnet run

API default olaraq işə düşəcək. Brauzerinizdə https://localhost:7182/swagger ünvanına daxil olaraq API endpoint-lərini test edə bilərsiniz.

📡 API Endpoint-ləri və Nümunələr
Sistemdə xəbərləri çəkmək üçün istifadə olunan əsas endpoint-lər və onlara aid request/response nümunələri aşağıdadır:

Mövcud Endpoint-lər
GET /api/News/GetArticles - Bütün məqalələri gətirir.

GET /api/News/GetBreakingArticle - Son dəqiqə xəbərlərini gətirir.

GET /api/News/GetFeatured - Önə çıxan xəbərləri gətirir.

GET /api/News/GetEditorsPick - Redaktorun seçimi olan xəbərləri gətirir.

GET /api/News/GetLiveArticle - Canlı yayımlanan xəbərləri gətirir.

📌 Nümunə 1: Məqalə Detalını Gətir (Get Article Detail)
Seçilmiş bir məqalənin bütün detallarını, oxunma müddətini və kateqoriyasını gətirir.

Endpoint: GET /api/News/GetArticleDetail/{id}

Parametr: id (integer) - Məqalənin unikal ID-si (Məsələn: 3).

Response Nümunəsi (200 OK):
{
"message": null,
"success": true,
"data": {
"id": 3,
"title": "Major 7.8 Magnitude Earthquake Strikes Off Coast of Japan, Tsunami Warning Issued",
"shortDescription": "A powerful undersea earthquake has triggered a tsunami warning for coastal areas of Japan...",
"imageUrl": "https://images.unsplash.com/photo-1584824486509...",
"content": "Japan's Meteorological Agency issued a major tsunami warning...",
"createdAt": "2025-06-05T14:15:00",
"readTimeMinutes": 4,
"isTrending": false,
"isBreaking": true,
"isLive": false,
"category": {
"name": "World",
"id": 4,
"slug": "world",
"badgeColor": "#8E44AD"
}
}
}

📌 Nümunə 2: Əlaqəli Məqalələri Gətir (Get Related Articles)
Oxunan bir məqalə ilə əlaqəli olan digər bənzər məqalələri və onların statistikasını siyahıya alır.

Endpoint: GET /api/News/RelatedArticles/{id}/related

Parametr: id (integer) - Əsas məqalənin ID-si (Məsələn: 2).

Response Nümunəsi (200 OK):
{
"message": null,
"success": true,
"data": [
{
"id": 6,
"title": "The New Geography of Wealth: Why Capital Is Fleeing Traditional Financial Centres",
"shortDescription": "From Singapore to Dubai and Abu Dhabi, a seismic shift...",
"imageUrl": "https://images.unsplash.com/photo-1486325212027...",
"category": {
"id": 2,
"name": "Business",
"badgeColor": "#2980B9"
},
"stats": {
"bookmarksCount": 761,
"likesCount": 2788,
"commentsCount": 183
}
}
],
"pagination": null
}
