const MockData = {
    "MockNotes": [
        {
            "title": "Wprowadzenie do systemu zarządzania treścią",
            "content": "System zarządzania treścią umożliwia łatwe tworzenie, edytowanie oraz publikowanie materiałów na stronie internetowej bez konieczności znajomości programowania.",
            "createdAt": "2026-03-01T10:15:23"
        },
        {
            "title": "Nowe funkcjonalności w aplikacji mobilnej",
            "content": "W najnowszej wersji aplikacji dodano tryb ciemny, poprawiono wydajność oraz wprowadzono możliwość personalizacji interfejsu użytkownika.",
            "createdAt": "2026-03-02T14:22:10"
        },
        {
            "title": "Poradnik dla początkujących użytkowników",
            "content": "Ten poradnik pomoże Ci rozpocząć pracę z aplikacją, przedstawiając podstawowe funkcje oraz najlepsze praktyki korzystania z systemu.",
            "createdAt": "2026-03-03T09:05:47"
        },
        {
            "title": "Aktualizacja zabezpieczeń systemu",
            "content": "Zaimplementowano nowe mechanizmy zabezpieczeń, które zwiększają ochronę danych użytkowników oraz zapobiegają nieautoryzowanemu dostępowi.",
            "createdAt": "2026-03-04T18:40:12"
        },
        {
            "title": "Zmiany w interfejsie użytkownika",
            "content": "Zaktualizowano wygląd aplikacji, aby był bardziej intuicyjny i przyjazny dla użytkownika, poprawiając ogólne doświadczenie korzystania.",
            "createdAt": "2026-03-05T11:33:55"
        },
        {
            "title": "Optymalizacja wydajności systemu",
            "content": "Wprowadzono zmiany w kodzie aplikacji, które znacząco poprawiają szybkość działania oraz zmniejszają zużycie zasobów systemowych.",
            "createdAt": "2026-03-06T16:20:30"
        },
        {
            "title": "Nowe opcje konfiguracji konta",
            "content": "Użytkownicy mogą teraz dostosować ustawienia konta według własnych preferencji, w tym powiadomienia oraz ustawienia prywatności.",
            "createdAt": "2026-03-07T08:12:09"
        },
        {
            "title": "Wprowadzenie trybu offline",
            "content": "Aplikacja umożliwia teraz korzystanie z wybranych funkcji bez dostępu do internetu, co zwiększa jej użyteczność w różnych warunkach.",
            "createdAt": "2026-03-08T13:47:21"
        },
        {
            "title": "Integracja z zewnętrznymi usługami",
            "content": "Dodano możliwość integracji z popularnymi usługami zewnętrznymi, co pozwala na rozszerzenie funkcjonalności aplikacji.",
            "createdAt": "2026-03-09T19:05:00"
        },
        {
            "title": "Poprawki błędów zgłoszonych przez użytkowników",
            "content": "Naprawiono liczne błędy zgłoszone przez społeczność, co znacząco poprawia stabilność i niezawodność działania aplikacji.",
            "createdAt": "2026-03-10T07:55:44"
        },
        {
            "title": "Nowy moduł raportowania danych",
            "content": "Użytkownicy mogą generować szczegółowe raporty dotyczące aktywności oraz analizować dane w przejrzysty i wygodny sposób.",
            "createdAt": "2026-03-11T15:18:36"
        },
        {
            "title": "Ulepszenia w systemie powiadomień",
            "content": "Powiadomienia zostały zoptymalizowane, aby były bardziej trafne i mniej uciążliwe, zwiększając komfort użytkowania aplikacji.",
            "createdAt": "2026-03-12T12:02:11"
        },
        {
            "title": "Rozszerzenie funkcji wyszukiwania",
            "content": "Dodano zaawansowane opcje filtrowania wyników wyszukiwania, co ułatwia odnalezienie potrzebnych informacji w systemie.",
            "createdAt": "2026-03-13T17:29:58"
        },
        {
            "title": "Wsparcie dla wielu języków",
            "content": "Aplikacja została rozszerzona o obsługę wielu języków, co pozwala użytkownikom z różnych krajów korzystać z niej wygodnie.",
            "createdAt": "2026-03-14T09:44:20"
        },
        {
            "title": "Automatyczne kopie zapasowe danych",
            "content": "System automatycznie tworzy kopie zapasowe danych użytkownika, zapewniając bezpieczeństwo i możliwość odzyskania informacji.",
            "createdAt": "2026-03-15T21:10:05"
        }
    ],
    "MockSubjects": [
        {
            "nazwa": "Matematyka",
            "opis": "Przedmiot obejmuje podstawowe oraz zaawansowane zagadnienia matematyczne, w tym analizę, algebrę i elementy statystyki. Studenci uczą się rozwiązywania problemów oraz logicznego myślenia w kontekście praktycznych zastosowań.",
            "liczba_grup": 3,
            "liczba_studentow": 72,
            "najblizsze_zajecia": "Poniedziałek 08:00"
        },
        {
            "nazwa": "Fizyka",
            "opis": "Kurs wprowadza w podstawy fizyki klasycznej oraz elementy fizyki współczesnej. Omawiane są zagadnienia związane z ruchem, energią, falami oraz podstawami elektromagnetyzmu.",
            "liczba_grup": 2,
            "liczba_studentow": 48,
            "najblizsze_zajecia": "Wtorek 10:00"
        },
        {
            "nazwa": "Informatyka",
            "opis": "Zajęcia skupiają się na podstawach programowania, struktur danych oraz algorytmach. Studenci poznają również podstawy tworzenia aplikacji oraz pracy z bazami danych.",
            "liczba_grup": 4,
            "liczba_studentow": 96,
            "najblizsze_zajecia": "Środa 12:30"
        },
        {
            "nazwa": "Historia",
            "opis": "Przedmiot obejmuje przegląd najważniejszych wydarzeń historycznych od starożytności do czasów współczesnych, z naciskiem na analizę przyczyn i skutków oraz rozwój cywilizacji.",
            "liczba_grup": 2,
            "liczba_studentow": 40,
            "najblizsze_zajecia": "Czwartek 09:15"
        },
        {
            "nazwa": "Biologia",
            "opis": "Kurs obejmuje podstawy biologii komórki, genetyki oraz ekologii. Studenci poznają mechanizmy funkcjonowania organizmów żywych oraz ich interakcje ze środowiskiem.",
            "liczba_grup": 3,
            "liczba_studentow": 60,
            "najblizsze_zajecia": "Piątek 11:00"
        },
        {
            "nazwa": "Chemia",
            "opis": "Zajęcia obejmują podstawy chemii ogólnej i organicznej, w tym reakcje chemiczne, strukturę atomu oraz właściwości substancji chemicznych.",
            "liczba_grup": 2,
            "liczba_studentow": 45,
            "najblizsze_zajecia": "Poniedziałek 13:45"
        },
        {
            "nazwa": "Język angielski",
            "opis": "Kurs rozwija umiejętności komunikacyjne w języku angielskim, obejmując gramatykę, słownictwo oraz konwersacje w różnych kontekstach życia codziennego i zawodowego.",
            "liczba_grup": 5,
            "liczba_studentow": 120,
            "najblizsze_zajecia": "Wtorek 08:30"
        },
        {
            "nazwa": "Geografia",
            "opis": "Przedmiot obejmuje zagadnienia związane z geografią fizyczną i społeczno-ekonomiczną, w tym analizę środowiska naturalnego oraz procesów zachodzących na Ziemi.",
            "liczba_grup": 2,
            "liczba_studentow": 38,
            "najblizsze_zajecia": "Środa 14:00"
        }
    ],
    "MockStudents":[
        {
            "studentCode": "STU001",
            "firstName": "Jan",
            "lastName": "Kowalski",
            "additionalInfo": "Student informatyki, zainteresowany frontendem i Reactem.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych"]
        },
        {
            "studentCode": "STU002",
            "firstName": "Anna",
            "lastName": "Nowak",
            "additionalInfo": "Specjalizuje się w analizie danych i Pythonie.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Matematyka Stosowana"]
        },
        {
            "studentCode": "STU003",
            "firstName": "Piotr",
            "lastName": "Wiśniewski",
            "additionalInfo": "Interesuje się sztuczną inteligencją oraz machine learning.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe", "Plastyka", "Kulturoznawstwo"]
        },
        {
            "studentCode": "STU004",
            "firstName": "Katarzyna",
            "lastName": "Wójcik",
            "additionalInfo": "Członkini koła naukowego, pasjonatka UX/UI.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU005",
            "firstName": "Tomasz",
            "lastName": "Kamiński",
            "additionalInfo": "Programuje w Javie, pracuje nad aplikacjami backendowymi.", 
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU006",
            "firstName": "Magdalena",
            "lastName": "Lewandowska",
            "additionalInfo": "Zainteresowana cyberbezpieczeństwem i sieciami komputerowymi.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU007",
            "firstName": "Paweł",
            "lastName": "Zieliński",
            "additionalInfo": "Tworzy aplikacje mobilne w Flutterze.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU008",
            "firstName": "Agnieszka",
            "lastName": "Szymańska",
            "additionalInfo": "Specjalizuje się w testowaniu oprogramowania.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU009",
            "firstName": "Michał",
            "lastName": "Dąbrowski",
            "additionalInfo": "Pasjonat DevOps i automatyzacji procesów.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU010",
            "firstName": "Karolina",
            "lastName": "Kozłowska",
            "additionalInfo": "Interesuje się projektowaniem graficznym i brandingiem.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU011",
            "firstName": "Łukasz",
            "lastName": "Jankowski",
            "additionalInfo": "Zajmuje się tworzeniem gier komputerowych.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU012",
            "firstName": "Natalia",
            "lastName": "Mazur",
            "additionalInfo": "Specjalizuje się w bazach danych i SQL.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU013",
            "firstName": "Krzysztof",
            "lastName": "Krawczyk",
            "additionalInfo": "Interesuje się systemami embedded i elektroniką.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU014",
            "firstName": "Monika",
            "lastName": "Piotrowska",
            "additionalInfo": "Aktywna w projektach open source.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        },
        {
            "studentCode": "STU015",
            "firstName": "Adam",
            "lastName": "Grabowski",
            "additionalInfo": "Zainteresowany chmurą obliczeniową i AWS.",
            "studentGroups":["Cyberbezpieczeństwo", "Analiza Danych", "Sztuczna Inteligencja", "Sieci Komputerowe"]
        }
    ],
    "MockGroups":[
        {
            "nazwa": "Informatyka Stosowana – Grupa A",
            "liczba_przedmiotow": 5,
            "liczba_studentow": 28,
            "najblizsze_zajecia": "Wtorek 8:30"
        },
        {
            "nazwa": "Programowanie Webowe – Grupa B",
            "liczba_przedmiotow": 4,
            "liczba_studentow": 24,
            "najblizsze_zajecia": "Wtorek 10:00"
        },
        {
            "nazwa": "Bazy Danych – Grupa C",
            "liczba_przedmiotow": 3,
            "liczba_studentow": 30,
            "najblizsze_zajecia": "Poniedziałek 12:30"
        },
        {
            "nazwa": "Sieci Komputerowe – Grupa D",
            "liczba_przedmiotow": 4,
            "liczba_studentow": 26,
            "najblizsze_zajecia": "Czwartek 9:30"
        },
        {
            "nazwa": "Sztuczna Inteligencja – Grupa E",
            "liczba_przedmiotow": 5,
            "liczba_studentow": 22,
            "najblizsze_zajecia": "Czwartek 13:00"
        },
        {
            "nazwa": "Inżynieria Oprogramowania – Grupa F",
            "liczba_przedmiotow": 6,
            "liczba_studentow": 27,
            "najblizsze_zajecia": "Piątek 8:00"
        },
        {
            "nazwa": "Systemy Operacyjne – Grupa G",
            "liczba_przedmiotow": 3,
            "liczba_studentow": 25,
            "najblizsze_zajecia": "Poniedziałek 10:00"
        },
        {
            "nazwa": "Analiza Danych – Grupa H",
            "liczba_przedmiotow": 4,
            "liczba_studentow": 23,
            "najblizsze_zajecia": "Piątek 10:00"
        },
        {
            "nazwa": "Cyberbezpieczeństwo – Grupa I",
            "liczba_przedmiotow": 5,
            "liczba_studentow": 21,
            "najblizsze_zajecia": "Czwartek 9:30"
        },
        {
            "nazwa": "Grafika Komputerowa – Grupa J",
            "liczba_przedmiotow": 4,
            "liczba_studentow": 20,
            "najblizsze_zajecia": "Środa 11:30"
        }
    ]
}   

export default MockData;
