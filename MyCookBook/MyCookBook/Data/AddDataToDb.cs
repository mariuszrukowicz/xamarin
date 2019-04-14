using MyCookBook.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCookBook.Data
{
    public static class AddDataToDb
    {
        public  static void AddRecipe()
        {
            List<Recipe> recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1,
                    AddedDate = DateTime.UtcNow,
                    Name="Brulee z szafranem",
                    Description = "Podgrzej w rondlu śmietanę do temperatury 60-70C.\n"+
                    "Dodaj nitki szafranu i przykryj rondel przezroczystą folią. Zdejmij z ognia i pozostaw na 2 godziny.\n"+
                    "Po tym czasie podgrzej ponownie śmietanę do 80C\n"+
                    "Napełnij wodą i podgrzej SousVide do temperatury 85C\n"+
                    "W misce ubij żółtka z cukrem do momentu rozpuszczenia się cukru i uzyskania puszystości.\n"+
                    "Powoli wlewaj śmietanę, chochelka po chochelce, ubijając ją z jajkami. Mieszaj dokładnie.\n"+
                    "Następnie przelej kremową miksturę do dużego (ok. 4l) worka próżniowego i pozbywszy się z niego powietrza, szczelnie zamknij.\n"+
                    "Zanurz worek w SousVide i gotuj przez godzinę.\n"+
                    "Po ugotowaniu, otwórz worek i przelej miksturę do żaroodpornych miseczek, następnie je przykryj i włóż do lodówki na 24 godziny.\n"+
                    "Przed podaniem wyjmij z lodówki deser, aby się ogrzał do temperatury pokojowej, po czym delikatnie posyp każdą muffinkę cukrem i \n" +
                    "Przy użyciu np. zapalniczki przypal cukier, aż zbrązowieje.\n"+
                    "Podawaj od razu.\n"




                    ,
                    Image= "brulee"
                },
                new Recipe()
                {
                    Id = 2,
                    AddedDate = DateTime.UtcNow,
                    Name="Sałatka grecka według Funky Gourmet",
                    Description= "Zmiksuj wszystkie składniki przy pomocy blendera ręcznego do czasu aż mikstura ulegnie ujednoliceniu.\n"+
                    "Ułóż kilka warstw mokrego muślinu na durszlak.\n"+
                    " Wyłóż miksturę na durszlak i zostaw na ok. 1 minutę do odsączenia.\n"+
                    "Wylej pierwszą wodę.\n"+
                    "Wstaw produkt w durszlaku z muślinem na 4 godziny do lodówki do dalszego odsączenia.\n"+
                    "Zamroź miksturę w PacoJet. Jeśli nie masz PacoJet, zastosuj instrukcję poniżej.\n"+
                    "Gdy produkt będzie zamrożony, zmiksuj go w PacoJet do uzyskania delikatnej, białej granity.\n"+
                    "JEŚLI NIE MASZ PACOJET: Bez urządzenia trudno będzie osiągnąć tę samą, delikatną konsystencję, jednak w zamian za to można zrobić klasyczną granitę.\n W tym celu wstaw miksturę do zamrażarki i co jakiś czas skrob ją widelcem, aby osiągnąć płatkowatą",
                    Image= "grecka"
                },
                new Recipe()
                {
                    Id = 3,
                    AddedDate = DateTime.UtcNow,
                    Name="Polędwica wołowa z pesto i szparagami",
                    Description= "Napełnij wodą Sous-Vide i podgrzej do temperatury 56.5 stopni Celsjusza."+
                    "Równomiernie przypraw mięso solą i pieprzem, następnie włóż je do worków próżniowych (po dwie porcje do każdego) i szczelnie zamknij.\n"+
                    "Zanurz worki z mięsem w cyrkulatorze i ustaw czasomierz na 2 godziny. Jest to minimalny czas gotowania.\n Mięso może zostać w Sous-Vide dłużej, ale w pełni ugotowane będzie już po 2 godzinach.\n"+
                    "W międzyczasie blanszuj liście bazylii we wrzątku przez około 30 sekund. Następnie wrzuć je do miski z zimną wodą,\n żeby się nie rozgotowały. Po chwili wyjmij je z wody, osusz i drobno pokrój.\n"+
                    "Z czosnkiem zrób to samo co z bazylią.\n"+
                    "Do malaksera włóż czosnek, bazylię i parmezan. Dodaj oliwę z oliwek oraz łyżeczkę soli. Całość blenduj do uzyskania gładkiej konsystencji.\n"+
                    "Dodaj tyle soku z cytryny, aby uzyskać odpowiedni dla siebie smak.\n"+
                    "Włóż pojedynczo szparagi do worków próżniowych. Dodaj do smaku sól oraz odrobinę pesto. Zamknij szczelnie worek.\n"+
                    "Zanurz szparagi w wannie Sous-Vide obok mięsa na 15 minut, następnie wyjmij i otwórz worki.\n"+
                    "Na dobrze naoliwionym grillu bądź patelni grillowej podsmażaj steki na dużym ogniu przez 30-45 sekund z każdej strony.\n"+
                    "Podawaj ze szparagami i dodatkowym pesto wedle życzenia.\n",
                    Image= "beef"
                },
               
                               
            };

            List<Igredient> igredients = new List<Igredient>()
            {
                new Igredient(){ Name = "Śmietana kremowa", Quantity= 1, Unit = "l", Id =1, RecipeId = 1},
                new Igredient(){ Name = "Cukier", Quantity= 200, Unit = "g", Id =2, RecipeId = 1},
                new Igredient(){ Name = "Żółtka jaja", Quantity= 8, Unit = "szt", Id =3, RecipeId = 1},
                new Igredient(){ Name = "Szafran", Quantity= 1, Unit = "g", Id =4, RecipeId = 1},
               
            };

            recipes.ForEach(async r => await App.LocalDB.SaveItem(r));
            igredients.ForEach(async i => await App.LocalDB.SaveItem(i));
        }
    }
}
