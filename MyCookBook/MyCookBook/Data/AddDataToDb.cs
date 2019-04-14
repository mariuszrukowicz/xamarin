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
                    Name="Pierogi ruskie",
                    Description = "Ciasto\nZ mąki formujemy kopczyk, robimy wgłębienie do którego wlewamy olej, żółtko,wsypujemy sól. "+
                    "Chwilkę wyrabiamy następnie powoli wlewamy wodę i zarabiamy ciasto nożem. Na końcu dokładnie wyrabiamy ciasto rękami, im dłużej tym"+
                    " ciasto będzie bardziej miękkie i elastyczne. Zawijamy w folię i odstawiamy na chwilkę by odpoczęło.Rozwałkowujemy na lekko oprószonej mąką stolnicy, "+
                    "wykrawamy kółka na pierogi, przykrywamy ściereczką by chronić ciasto przed nadmiernym wysuszeniem. \nFarsz\nCebulę kroimy w drobną kosteczkę, wrzucamy na"+
                    " rozgrzany olej i szklimy, aż będzie miękka.\nSer i ziemniaki przepuszczamy przez maszynkę, dodajemy usmażoną cebulkę, doprawimy do smaku.\nKładziemy po łyżeczce"+
                    " farszu na ciasto, zalepiamy.\nPierogi gotujemy we wrzącej osolonej wodzie około 3 - 5 minut na mniejszym gazie.\nOdcedzamy i podajemy okraszane masłem lub "+
                    "usmażoną cebulką.",
                    Image= "img1"
                },
                new Recipe()
                {
                    Id = 2,
                    AddedDate = DateTime.UtcNow,
                    Name="Pierogi z mięsem",
                    Description= "Na stolnicę wysypac mąkę, w środek wlac wodę ze stopionym masłem ,jajko oraz sól, Wyrobic ciasto i odstawić na 30 minut.\nMięso wrzucic do garnka,"+
                    " zalać wodą, dodać ziele angielskie oraz liść laurowy i gotowac na wolnym ogniu przez godzinę.Mieso ostudzic, zmielic w maszynce, cebulke zeszklić na oleju."+
                    " Wszystkie składniki połączyc ze soba czyli : kasze mięso cebulkę , jajko, oraz przyprawy.\n Wszystko wymieszac.\nCiasto na pierogi cienko rozwałkować wykrawać"+
                    " szklanką kółka, w środek nakładać łyżką gotowy farsz, sklejać.\nGotowac 5 minut od momentu wypłynięcia.\nGotowe mozna obsypać delikatnie stopiona słoniną",
                    Image= "img2"
                },
                new Recipe()
                {
                    Id = 3,
                    AddedDate = DateTime.UtcNow,
                    Name="Burger wołowy",
                    Description= "polędwice wołową siekamy na desce ostrym, dużym nożem w paseczki, następnie w drobną kostkę (jak na tatara).\n Cebulkę drobno siekamy.\nMięso mieszamy"+
                    " z cebulką, pieprzem i solą. Ugniatamy dobrze i najlepiej na papierze do pieczenia formujemy burgery nożem, mocno dociskając.\n Wkładamy na ok. 30 min do zamrażalki."+
                    " Po tym czasie wyjmujemy i smażymy na mocno rozgrzanym oleju rzepakowym z jednej strony, zmniejszamy gaz i przykrywamy smażąc z drugiej strony, po czym ponownie"+
                    " obracamy, układamy na burgerach ser, przykrywamy i smażymy jeszcze chwilkę, aż ser się dokładnie stopi. Wtedy powinny być dobrze wysmażone i nie krwiste.\n"+
                    " Jeśli ktoś lubi takie wystarczy tylko raz obrócić i nie trzeba zmniejszać gazu.\n Podaje w zgrillowanej bułce z dodatkami.",
                    Image= "img3"
                },
                new Recipe()
                {
                    Id = 4,
                    AddedDate = DateTime.UtcNow,
                    Name="Spaghetti",
                    Description= "Cebulę i czosnek obieram, kroję, szklę na maśle, dodaję oczyszczoną i pokrojoną paprykę, podsmażam, dodaje umyte i pokrojone pieczarki, podsmażam.\n"+
                    "Do całości dodaję mięso mielone, podsmażam, dodaje przyprawy, mieszam. Dodaje przecier pomidorowy, dusze.\nW osolonym wrzątku 8 minut gotuje makaron, odcedzam."+
                    "\nMakaron podaje z sosem.",
                    Image= "img4"
                },                
            };

            List<Igredient> igredients = new List<Igredient>()
            {
                new Igredient(){ Name = "Mąka Pszenna", Quantity= 200, Unit = "g", Id =1, RecipeId = 1},
                new Igredient(){ Name = "Wrząca woda", Quantity= 125, Unit = "ml", Id =2, RecipeId = 1},
                new Igredient(){ Name = "Jajko", Quantity= 1, Unit = "szt", Id =3, RecipeId = 1},
                new Igredient(){ Name = "Masło", Quantity= 25, Unit = "g", Id =4, RecipeId = 1},
                new Igredient(){ Name = "Ser Biały", Quantity= 500, Unit = "g", Id =5, RecipeId = 1},
                new Igredient(){ Name = "Ziemniaki", Quantity= 500, Unit = "g", Id =6, RecipeId = 1},
                new Igredient(){ Name = "Sól", Quantity= 2, Unit = "g", Id =7, RecipeId = 1},

            };

            recipes.ForEach(async r => await App.LocalDB.SaveItem(r));
            igredients.ForEach(async i => await App.LocalDB.SaveItem(i));
        }
    }
}
