# Projekt School.MVC - System Zarządzania Studentami

## Opis

Aplikacja webowa stworzona w technologii ASP.NET MVC z wykorzystaniem Clean Architecture oraz wzorca CQRS (Command Query Responsibility Segregation). Aplikacja służy do zarządzania informacjami o uczniach i oferuje szereg funkcjonalności, takich jak operacje CRUD (Create, Read, Update, Delete) z zastosowaniem notyfikacji, paginacja, wyszukiwanie uczniów, dynamiczne renderowanie ocen, tworzenie i usuwanie przedmiotów szkolnych.


![image](https://github.com/Brajnn/ExchangeAPI/assets/120382137/daaac4c8-ab44-46ef-a429-1cc1cd5d4602)


## Technologie i Wzorce

- **Entity Framework:** Korzystamy z Entity Framework do obsługi operacji bazodanowych, co zapewnia wygodne mapowanie obiektowo-relacyjne.
- **Clean Architecture:** Projekt został zbudowany w oparciu o Clean Architecture, co umożliwia łatwe rozdzielenie warstw i utrzymanie modularności kodu.
- **CQRS (Command Query Responsibility Segregation):** Zastosowałem wzorzec CQRS do projektu, dzięki czemu oddzielamy operacje zapisu (komendy) od operacji odczytu (zapytania), co przyczynia się do lepszej skalowalności i utrzymania systemu.
- **Notyfikacje:** Użyłem notyfikacje w procesie dodawania uczniów, aby informować użytkownika o rezultatach operacji.
  
  ![Zrzut ekranu (1488)](https://github.com/Brajnn/ExchangeAPI/assets/120382137/369c7853-1a41-43f3-8553-ea594408826f)


## Funkcjonalności


### 1. Paginacja

- Rozdzielenie listy uczniów na strony w celu łatwiejszej nawigacji.
- Umożliwienie użytkownikowi przeglądania różnych fragmentów listy.
  
![Zrzut ekranu (145)](https://github.com/Brajnn/ExchangeAPI/assets/120382137/bc421439-9ce4-4f17-81ba-bf2091316bb1)

### 2. Operacje CRUD z Notyfikacjami

- Dodawanie nowych uczniów z dynamicznym wykorzystaniem notyfikacji.
- Dodawanie przedmiotów szkolnych.
- Usuwanie istniejących uczniów.
- Usuwanie przedmiotów szkolnych.
- Edytowanie danych uczniów.
- Przeglądanie listy wszystkich uczniów i przedmiotów.
  

  ![Zrzut ekranu (1444)](https://github.com/Brajnn/ExchangeAPI/assets/120382137/0e0fde1b-6b9c-4b1a-a335-569a347a5ae8)


  ![Zrzut ekranu (146)](https://github.com/Brajnn/ExchangeAPI/assets/120382137/18f085fb-e504-49a4-ac1b-1a55113a9170)


### 3. Wyszukiwanie Uczniów

- Możliwość szybkiego odnajdywania uczniów na podstawie ich nazw.
- Efektywne wyszukiwanie nawet w przypadku dużej liczby uczniów.
![image](https://github.com/Brajnn/ExchangeAPI/assets/120382137/d28d2f22-6a09-42a6-bb58-e36d2cff0fdc)

### 4. Wyświetlanie Ocen

- Przejrzyste prezentowanie ocen przypisanych do każdego ucznia.
- Dostęp do szczegółowych informacji o każdym uczniu
 ![Zrzut ekranu (153)](https://github.com/Brajnn/ExchangeAPI/assets/120382137/ea147e19-b6ea-42dc-8f33-99bcdc493cd9)


### 5. Dynamiczne Renderowanie Ocen

- Dodawanie ocen i wykorzystanie dynamicznych komponentów do interaktywnego prezentowania.
- Aktualizacja ocen bez konieczności odświeżania całej strony.
  ![Zrzut ekranu (151)](https://github.com/Brajnn/ExchangeAPI/assets/120382137/3c6dfa37-bd00-4e77-9b3b-3f953c2a29c5)


## Stan Projektu

Aktualnie projekt jest w fazie rozwoju, co oznacza, że dodatkowe funkcjonalności i usprawnienia są planowane do wdrożenia w przyszłości. W miarę postępu prac, nowe aktualizacje będą udostępniane w repozytorium.


## Instalacja i Uruchamianie

Aby uruchomić projekt lokalnie, wykonaj następujące kroki:

1. Sklonuj repozytorium na swój lokalny komputer.
2. Otwórz projekt w środowisku programistycznym zgodnym z ASP.NET MVC.
3. Skonfiguruj połączenie do bazy danych (jeśli jest wymagane).
4. Uruchom projekt i otwórz przeglądarkę pod adresem `http://localhost:port`, gdzie `port` to numer portu na którym działa aplikacja.

---

**Uwaga:** Przed uruchomieniem projektu upewnij się, że spełnione są wszystkie wymagania systemowe oraz zainstalowane są niezbędne biblioteki i narzędzia.
