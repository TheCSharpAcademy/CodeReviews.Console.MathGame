using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("MathGameTests")]
namespace Math_Game.Application;

internal static class QuestionsRepository
{
    public static IEnumerable<Question> EasyQuestionsSum = new List<Question>
    {
        new Question("What's the result of 2 + 3?", "5"),
        new Question("What's the result of 7 + 4?", "11"),
        new Question("What's the result of 9 + 6?", "15"),
        new Question("What's the result of 12 + 5?", "17"),
        new Question("What's the result of 8 + 7?", "15"),
        new Question("What's the result of 10 + 4?", "14"),
        new Question("What's the result of 13 + 6?", "19"),
        new Question("What's the result of 20 + 5?", "25"),
        new Question("What's the result of 14 + 3?", "17"),
        new Question("What's the result of 11 + 8?", "19"),
        new Question("What's the result of 16 + 2?", "18"),
        new Question("What's the result of 25 + 4?", "29"),
        new Question("What's the result of 30 + 7?", "37"),
        new Question("What's the result of 21 + 6?", "27"),
        new Question("What's the result of 18 + 5?", "23"),
        new Question("What's the result of 32 + 8?", "40"),
        new Question("What's the result of 27 + 3?", "30"),
        new Question("What's the result of 40 + 6?", "46"),
        new Question("What's the result of 15 + 10?", "25"),
        new Question("What's the result of 22 + 7?", "29"),
        new Question("What's the result of 35 + 5?", "40"),
        new Question("What's the result of 19 + 1?", "20"),
        new Question("What's the result of 24 + 6?", "30"),
        new Question("What's the result of 31 + 9?", "40"),
        new Question("What's the result of 45 + 5?", "50"),
        new Question("What's the result of 50 + 10?", "60"),
        new Question("What's the result of 33 + 7?", "40"),
        new Question("What's the result of 42 + 8?", "50"),
        new Question("What's the result of 26 + 4?", "30"),
        new Question("What's the result of 17 + 2?", "19"),
        new Question("What's the result of 28 + 2?", "30"),
        new Question("What's the result of 36 + 4?", "40"),
        new Question("What's the result of 43 + 7?", "50"),
        new Question("What's the result of 52 + 8?", "60"),
        new Question("What's the result of 60 + 5?", "65"),
        new Question("What's the result of 70 + 10?", "80"),
        new Question("What's the result of 80 + 5?", "85"),
        new Question("What's the result of 90 + 10?", "100"),
        new Question("What's the result of 44 + 6?", "50"),
        new Question("What's the result of 55 + 5?", "60"),
        new Question("What's the result of 63 + 7?", "70"),
        new Question("What's the result of 72 + 8?", "80"),
        new Question("What's the result of 81 + 9?", "90"),
        new Question("What's the result of 34 + 6?", "40"),
        new Question("What's the result of 23 + 7?", "30"),
        new Question("What's the result of 12 + 8?", "20"),
        new Question("What's the result of 9 + 1?", "10"),
        new Question("What's the result of 7 + 3?", "10"),
        new Question("What's the result of 4 + 6?", "10"),
        new Question("What's the result of 3 + 5?", "8"),
        new Question("What's the result of 6 + 4?", "10")
    };
    public static IEnumerable<Question> MediumQuestionsSum = new List<Question>
    {
        new Question("What's the result of 125 + 234?", "359"),
        new Question("What's the result of 347 + 152?", "499"),
        new Question("What's the result of 216 + 385?", "601"),
        new Question("What's the result of 428 + 137?", "565"),
        new Question("What's the result of 563 + 214?", "777"),
        new Question("What's the result of 189 + 326?", "515"),
        new Question("What's the result of 275 + 418?", "693"),
        new Question("What's the result of 342 + 259?", "601"),
        new Question("What's the result of 451 + 328?", "779"),
        new Question("What's the result of 617 + 152?", "769"),
        new Question("What's the result of 238 + 471?", "709"),
        new Question("What's the result of 326 + 285?", "611"),
        new Question("What's the result of 514 + 273?", "787"),
        new Question("What's the result of 165 + 428?", "593"),
        new Question("What's the result of 372 + 419?", "791"),
        new Question("What's the result of 284 + 357?", "641"),
        new Question("What's the result of 493 + 216?", "709"),
        new Question("What's the result of 538 + 347?", "885"),
        new Question("What's the result of 621 + 289?", "910"),
        new Question("What's the result of 754 + 138?", "892"),
        new Question("What's the result of 467 + 355?", "822"),
        new Question("What's the result of 592 + 247?", "839"),
        new Question("What's the result of 318 + 496?", "814"),
        new Question("What's the result of 685 + 237?", "922"),
        new Question("What's the result of 429 + 386?", "815"),
        new Question("What's the result of 573 + 268?", "841"),
        new Question("What's the result of 746 + 189?", "935"),
        new Question("What's the result of 357 + 478?", "835"),
        new Question("What's the result of 618 + 295?", "913"),
        new Question("What's the result of 284 + 529?", "813"),
        new Question("What's the result of 437 + 386?", "823"),
        new Question("What's the result of 659 + 274?", "933"),
        new Question("What's the result of 728 + 165?", "893"),
        new Question("What's the result of 495 + 378?", "873"),
        new Question("What's the result of 846 + 127?", "973"),
        new Question("What's the result of 369 + 458?", "827"),
        new Question("What's the result of 527 + 396?", "923"),
        new Question("What's the result of 684 + 259?", "943"),
        new Question("What's the result of 735 + 186?", "921"),
        new Question("What's the result of 458 + 367?", "825"),
    };
    public static IEnumerable<Question> HardQuestionsSum = new List<Question>
    {
        new Question("What's the result of 1245 + 3786?", "5031"),
        new Question("What's the result of 5632 + 2479?", "8111"),
        new Question("What's the result of 7184 + 3627?", "10811"),
        new Question("What's the result of 4395 + 5876?", "10271"),
        new Question("What's the result of 8261 + 3948?", "12209"),
        new Question("What's the result of 6743 + 2589?", "9332"),
        new Question("What's the result of 9157 + 3846?", "13003"),
        new Question("What's the result of 4826 + 7195?", "12021"),
        new Question("What's the result of 3579 + 8642?", "12221"),
        new Question("What's the result of 6938 + 4756?", "11694"),
        new Question("What's the result of 1847 + 9365?", "11212"),
        new Question("What's the result of 7526 + 4893?", "12419"),
        new Question("What's the result of 6384 + 2759?", "9143"),
        new Question("What's the result of 8473 + 5968?", "14441"),
        new Question("What's the result of 5296 + 7834?", "13130"),
        new Question("What's the result of 9146 + 6875?", "16021"),
        new Question("What's the result of 3768 + 9457?", "13225"),
        new Question("What's the result of 6859 + 4276?", "11135"),
        new Question("What's the result of 7935 + 5684?", "13619"),
        new Question("What's the result of 4587 + 8269?", "12856"),
        new Question("What's the result of 12456 + 37891?", "50347"),
        new Question("What's the result of 56327 + 24185?", "80512"),
        new Question("What's the result of 71843 + 36279?", "108122"),
        new Question("What's the result of 43956 + 58724?", "102680"),
        new Question("What's the result of 82615 + 39487?", "122102"),
        new Question("What's the result of 67438 + 25896?", "93334"),
        new Question("What's the result of 91572 + 38469?", "130041"),
        new Question("What's the result of 48261 + 71958?", "120219"),
        new Question("What's the result of 35794 + 86423?", "122217"),
        new Question("What's the result of 69381 + 47569?", "116950"),
        new Question("What's the result of 18476 + 93652?", "112128"),
        new Question("What's the result of 75263 + 48937?", "124200"),
        new Question("What's the result of 63849 + 27596?", "91445"),
        new Question("What's the result of 84732 + 59681?", "144413"),
        new Question("What's the result of 52967 + 78345?", "131312"),
        new Question("What's the result of 91468 + 68759?", "160227"),
        new Question("What's the result of 37684 + 94573?", "132257"),
        new Question("What's the result of 68592 + 42786?", "111378"),
        new Question("What's the result of 79351 + 56847?", "136198"),
        new Question("What's the result of 45876 + 82694?", "128570"),
    };
    public static IEnumerable<Question> EasyQuestionsSubtraction = new List<Question>
    {
        new Question("What's the result of 8 - 3?", "5"),
        new Question("What's the result of 10 - 4?", "6"),
        new Question("What's the result of 15 - 5?", "10"),
        new Question("What's the result of 12 - 7?", "5"),
        new Question("What's the result of 20 - 8?", "12"),
        new Question("What's the result of 18 - 6?", "12"),
        new Question("What's the result of 14 - 9?", "5"),
        new Question("What's the result of 25 - 10?", "15"),
        new Question("What's the result of 30 - 7?", "23"),
        new Question("What's the result of 22 - 5?", "17"),
        new Question("What's the result of 17 - 8?", "9"),
        new Question("What's the result of 19 - 3?", "16"),
        new Question("What's the result of 35 - 5?", "30"),
        new Question("What's the result of 40 - 12?", "28"),
        new Question("What's the result of 28 - 9?", "19"),
        new Question("What's the result of 50 - 20?", "30"),
        new Question("What's the result of 45 - 15?", "30"),
        new Question("What's the result of 32 - 7?", "25"),
        new Question("What's the result of 27 - 13?", "14"),
        new Question("What's the result of 60 - 25?", "35"),
        new Question("What's the result of 38 - 18?", "20"),
        new Question("What's the result of 55 - 5?", "50"),
        new Question("What's the result of 42 - 12?", "30"),
        new Question("What's the result of 70 - 30?", "40"),
        new Question("What's the result of 100 - 25?", "75"),
    };
    public static IEnumerable<Question> MediumQuestionsSubtraction = new List<Question>
    {
        new Question("What's the result of 234 - 125?", "109"),
        new Question("What's the result of 347 - 152?", "195"),
        new Question("What's the result of 385 - 216?", "169"),
        new Question("What's the result of 428 - 137?", "291"),
        new Question("What's the result of 563 - 214?", "349"),
        new Question("What's the result of 526 - 189?", "337"),
        new Question("What's the result of 718 - 275?", "443"),
        new Question("What's the result of 642 - 259?", "383"),
        new Question("What's the result of 751 - 328?", "423"),
        new Question("What's the result of 917 - 152?", "765"),
        new Question("What's the result of 671 - 238?", "433"),
        new Question("What's the result of 826 - 285?", "541"),
        new Question("What's the result of 914 - 273?", "641"),
        new Question("What's the result of 728 - 165?", "563"),
        new Question("What's the result of 819 - 372?", "447"),
        new Question("What's the result of 684 - 357?", "327"),
        new Question("What's the result of 893 - 216?", "677"),
        new Question("What's the result of 945 - 347?", "598"),
        new Question("What's the result of 821 - 289?", "532"),
        new Question("What's the result of 754 - 138?", "616"),
        new Question("What's the result of 967 - 355?", "612"),
        new Question("What's the result of 842 - 247?", "595"),
        new Question("What's the result of 916 - 496?", "420"),
        new Question("What's the result of 985 - 237?", "748"),
        new Question("What's the result of 815 - 386?", "429"),
    };
    public static IEnumerable<Question> HardQuestionsSubtraction = new List<Question>
    {
        new Question("What's the result of 5378 - 1245?", "4133"),
        new Question("What's the result of 8111 - 2479?", "5632"),
        new Question("What's the result of 10811 - 3627?", "7184"),
        new Question("What's the result of 10271 - 4395?", "5876"),
        new Question("What's the result of 12209 - 3948?", "8261"),
        new Question("What's the result of 9332 - 2589?", "6743"),
        new Question("What's the result of 13003 - 3846?", "9157"),
        new Question("What's the result of 12021 - 4826?", "7195"),
        new Question("What's the result of 12221 - 3579?", "8642"),
        new Question("What's the result of 11694 - 4756?", "6938"),
        new Question("What's the result of 11212 - 1847?", "9365"),
        new Question("What's the result of 12419 - 4893?", "7526"),
        new Question("What's the result of 9143 - 2759?", "6384"),
        new Question("What's the result of 14441 - 5968?", "8473"),
        new Question("What's the result of 13130 - 5296?", "7834"),
        new Question("What's the result of 16021 - 6875?", "9146"),
        new Question("What's the result of 13225 - 3768?", "9457"),
        new Question("What's the result of 11135 - 4276?", "6859"),
        new Question("What's the result of 13619 - 5684?", "7935"),
        new Question("What's the result of 12856 - 4587?", "8269"),
        new Question("What's the result of 50347 - 12456?", "37891"),
        new Question("What's the result of 80512 - 24185?", "56327"),
        new Question("What's the result of 108122 - 36279?", "71843"),
        new Question("What's the result of 102680 - 43956?", "58724"),
        new Question("What's the result of 122102 - 39487?", "82615"),
        new Question("What's the result of 93334 - 25896?", "67438"),
        new Question("What's the result of 130041 - 38469?", "91572"),
        new Question("What's the result of 120219 - 48261?", "71958"),
        new Question("What's the result of 122217 - 35794?", "86423"),
        new Question("What's the result of 116950 - 47569?", "69381"),
    };
    public static IEnumerable<Question> EasyQuestionsMultiplication = new List<Question>
    {
        new Question("What's the result of 2 × 3?", "6"),
        new Question("What's the result of 4 × 5?", "20"),
        new Question("What's the result of 6 × 3?", "18"),
        new Question("What's the result of 7 × 4?", "28"),
        new Question("What's the result of 8 × 2?", "16"),
        new Question("What's the result of 9 × 3?", "27"),
        new Question("What's the result of 5 × 6?", "30"),
        new Question("What's the result of 7 × 5?", "35"),
        new Question("What's the result of 8 × 4?", "32"),
        new Question("What's the result of 9 × 5?", "45"),
        new Question("What's the result of 3 × 7?", "21"),
        new Question("What's the result of 6 × 6?", "36"),
        new Question("What's the result of 4 × 8?", "32"),
        new Question("What's the result of 7 × 7?", "49"),
        new Question("What's the result of 8 × 6?", "48"),
        new Question("What's the result of 9 × 7?", "63"),
        new Question("What's the result of 10 × 5?", "50"),
        new Question("What's the result of 12 × 3?", "36"),
        new Question("What's the result of 11 × 4?", "44"),
        new Question("What's the result of 15 × 2?", "30"),
        new Question("What's the result of 20 × 3?", "60"),
        new Question("What's the result of 14 × 5?", "70"),
        new Question("What's the result of 16 × 4?", "64"),
        new Question("What's the result of 18 × 5?", "90"),
        new Question("What's the result of 25 × 4?", "100"),
    };
    public static IEnumerable<Question> MediumQuestionsMultiplication = new List<Question>
    {
        new Question("What's the result of 12 × 14?", "168"),
        new Question("What's the result of 15 × 13?", "195"),
        new Question("What's the result of 17 × 12?", "204"),
        new Question("What's the result of 21 × 14?", "294"),
        new Question("What's the result of 23 × 15?", "345"),
        new Question("What's the result of 26 × 12?", "312"),
        new Question("What's the result of 18 × 17?", "306"),
        new Question("What's the result of 24 × 16?", "384"),
        new Question("What's the result of 27 × 13?", "351"),
        new Question("What's the result of 32 × 14?", "448"),
        new Question("What's the result of 35 × 12?", "420"),
        new Question("What's the result of 28 × 15?", "420"),
        new Question("What's the result of 31 × 17?", "527"),
        new Question("What's the result of 36 × 14?", "504"),
        new Question("What's the result of 42 × 13?", "546"),
        new Question("What's the result of 45 × 16?", "720"),
        new Question("What's the result of 38 × 21?", "798"),
        new Question("What's the result of 47 × 12?", "564"),
        new Question("What's the result of 52 × 15?", "780"),
        new Question("What's the result of 54 × 18?", "972"),
        new Question("What's the result of 63 × 14?", "882"),
        new Question("What's the result of 72 × 13?", "936"),
        new Question("What's the result of 65 × 16?", "1040"),
        new Question("What's the result of 78 × 12?", "936"),
        new Question("What's the result of 84 × 15?", "1260"),
    };
    public static IEnumerable<Question> HardQuestionsMultiplication = new List<Question>
    {
        new Question("What's the result of 125 × 24?", "3000"),
        new Question("What's the result of 137 × 32?", "4384"),
        new Question("What's the result of 246 × 15?", "3690"),
        new Question("What's the result of 318 × 27?", "8586"),
        new Question("What's the result of 425 × 36?", "15300"),
        new Question("What's the result of 512 × 24?", "12288"),
        new Question("What's the result of 637 × 18?", "11466"),
        new Question("What's the result of 724 × 31?", "22444"),
        new Question("What's the result of 815 × 26?", "21190"),
        new Question("What's the result of 936 × 17?", "15912"),
        new Question("What's the result of 247 × 43?", "10621"),
        new Question("What's the result of 358 × 29?", "10382"),
        new Question("What's the result of 469 × 34?", "15946"),
        new Question("What's the result of 573 × 28?", "16044"),
        new Question("What's the result of 684 × 37?", "25308"),
        new Question("What's the result of 795 × 42?", "33390"),
        new Question("What's the result of 826 × 35?", "28910"),
        new Question("What's the result of 917 × 46?", "42182"),
        new Question("What's the result of 438 × 57?", "24966"),
        new Question("What's the result of 759 × 63?", "47717"),
        new Question("What's the result of 1245 × 23?", "28635"),
        new Question("What's the result of 1532 × 34?", "52088"),
        new Question("What's the result of 2147 × 26?", "55822"),
        new Question("What's the result of 3268 × 17?", "55556"),
        new Question("What's the result of 4125 × 28?", "115500"),
    };
    public static IEnumerable<Question> EasyQuestionsDivision = new List<Question>
    {
        new Question("What's the result of 6 ÷ 2?", "3"),
        new Question("What's the result of 10 ÷ 2?", "5"),
        new Question("What's the result of 12 ÷ 3?", "4"),
        new Question("What's the result of 15 ÷ 5?", "3"),
        new Question("What's the result of 16 ÷ 4?", "4"),
        new Question("What's the result of 18 ÷ 3?", "6"),
        new Question("What's the result of 20 ÷ 5?", "4"),
        new Question("What's the result of 21 ÷ 3?", "7"),
        new Question("What's the result of 24 ÷ 4?", "6"),
        new Question("What's the result of 25 ÷ 5?", "5"),
        new Question("What's the result of 27 ÷ 3?", "9"),
        new Question("What's the result of 28 ÷ 4?", "7"),
        new Question("What's the result of 30 ÷ 5?", "6"),
        new Question("What's the result of 32 ÷ 4?", "8"),
        new Question("What's the result of 35 ÷ 5?", "7"),
        new Question("What's the result of 36 ÷ 6?", "6"),
        new Question("What's the result of 40 ÷ 5?", "8"),
        new Question("What's the result of 42 ÷ 6?", "7"),
        new Question("What's the result of 45 ÷ 5?", "9"),
        new Question("What's the result of 48 ÷ 6?", "8"),
        new Question("What's the result of 49 ÷ 7?", "7"),
        new Question("What's the result of 54 ÷ 6?", "9"),
        new Question("What's the result of 56 ÷ 7?", "8"),
        new Question("What's the result of 63 ÷ 7?", "9"),
        new Question("What's the result of 72 ÷ 8?", "9"),
    };
    public static IEnumerable<Question> MediumQuestionsDivision = new List<Question>
    {
        new Question("What's the result of 144 ÷ 12?", "12"),
        new Question("What's the result of 156 ÷ 12?", "13"),
        new Question("What's the result of 169 ÷ 13?", "13"),
        new Question("What's the result of 196 ÷ 14?", "14"),
        new Question("What's the result of 225 ÷ 15?", "15"),
        new Question("What's the result of 288 ÷ 16?", "18"),
        new Question("What's the result of 324 ÷ 18?", "18"),
        new Question("What's the result of 357 ÷ 17?", "21"),
        new Question("What's the result of 384 ÷ 16?", "24"),
        new Question("What's the result of 420 ÷ 14?", "30"),
        new Question("What's the result of 432 ÷ 18?", "24"),
        new Question("What's the result of 468 ÷ 18?", "26"),
        new Question("What's the result of 495 ÷ 15?", "33"),
        new Question("What's the result of 504 ÷ 21?", "24"),
        new Question("What's the result of 528 ÷ 22?", "24"),
        new Question("What's the result of 546 ÷ 21?", "26"),
        new Question("What's the result of 576 ÷ 24?", "24"),
        new Question("What's the result of 612 ÷ 18?", "34"),
        new Question("What's the result of 624 ÷ 24?", "26"),
        new Question("What's the result of 648 ÷ 27?", "24"),
        new Question("What's the result of 675 ÷ 25?", "27"),
        new Question("What's the result of 720 ÷ 24?", "30"),
        new Question("What's the result of 756 ÷ 27?", "28"),
        new Question("What's the result of 816 ÷ 24?", "34"),
        new Question("What's the result of 864 ÷ 27?", "32"),
    };
    public static IEnumerable<Question> HardQuestionsDivision = new List<Question>
    {
        new Question("What's the result of 1440 ÷ 24?", "60"),
        new Question("What's the result of 1728 ÷ 36?", "48"),
        new Question("What's the result of 2184 ÷ 28?", "78"),
        new Question("What's the result of 2592 ÷ 36?", "72"),
        new Question("What's the result of 3072 ÷ 48?", "64"),
        new Question("What's the result of 3456 ÷ 54?", "64"),
        new Question("What's the result of 4095 ÷ 45?", "91"),
        new Question("What's the result of 4536 ÷ 56?", "81"),
        new Question("What's the result of 5184 ÷ 72?", "72"),
        new Question("What's the result of 5775 ÷ 75?", "77"),
        new Question("What's the result of 6048 ÷ 84?", "72"),
        new Question("What's the result of 6912 ÷ 96?", "72"),
        new Question("What's the result of 7392 ÷ 88?", "84"),
        new Question("What's the result of 8064 ÷ 96?", "84"),
        new Question("What's the result of 8748 ÷ 108?", "81"),
        new Question("What's the result of 9216 ÷ 128?", "72"),
        new Question("What's the result of 10368 ÷ 144?", "72"),
        new Question("What's the result of 11520 ÷ 160?", "72"),
        new Question("What's the result of 12960 ÷ 180?", "72"),
        new Question("What's the result of 15120 ÷ 210?", "72"),
        new Question("What's the result of 17280 ÷ 240?", "72"),
        new Question("What's the result of 19440 ÷ 270?", "72"),
        new Question("What's the result of 21600 ÷ 288?", "75"),
        new Question("What's the result of 23760 ÷ 330?", "72"),
        new Question("What's the result of 26880 ÷ 336?", "80"),
    };
    public static IEnumerable<Question> RandomDifficultySumQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for(int i = 0; i < 5; i++)
        {
            int difficulty = _random.Next(1, 4);
            _questions.Add(difficulty switch
            {
                1 => EasyQuestionsSum.ElementAt(_random.Next(EasyQuestionsSum.Count())),
                2 => MediumQuestionsSum.ElementAt(_random.Next(MediumQuestionsSum.Count())),
                3 => HardQuestionsSum.ElementAt(_random.Next(HardQuestionsSum.Count())),
            });
        }
        return _questions;
    }
    public static IEnumerable<Question> RandomDifficultySubtractionQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int difficulty = _random.Next(1, 4);
            _questions.Add(difficulty switch
            {
                1 => EasyQuestionsSubtraction.ElementAt(_random.Next(EasyQuestionsSubtraction.Count())),
                2 => MediumQuestionsSubtraction.ElementAt(_random.Next(MediumQuestionsSubtraction.Count())),
                3 => HardQuestionsSubtraction.ElementAt(_random.Next(HardQuestionsSubtraction.Count())),
            });
        }
        return _questions;
    }
    public static IEnumerable<Question> RandomDifficultyMultiplicationQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int difficulty = _random.Next(1, 4);
            _questions.Add(difficulty switch
            {
                1 => EasyQuestionsMultiplication.ElementAt(_random.Next(EasyQuestionsMultiplication.Count())),
                2 => MediumQuestionsMultiplication.ElementAt(_random.Next(MediumQuestionsMultiplication.Count())),
                3 => HardQuestionsMultiplication.ElementAt(_random.Next(HardQuestionsMultiplication.Count())),
            });
        }
        return _questions;
    }
    public static IEnumerable<Question> RandomDifficultyDivisionQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int difficulty = _random.Next(1, 4);
            _questions.Add(difficulty switch
            {
                1 => EasyQuestionsDivision.ElementAt(_random.Next(EasyQuestionsDivision.Count())),
                2 => MediumQuestionsDivision.ElementAt(_random.Next(MediumQuestionsDivision.Count())),
                3 => HardQuestionsDivision.ElementAt(_random.Next(HardQuestionsDivision.Count())),
            });
        }
        return _questions;
    }

    internal static IEnumerable<Question> EasyDifficultyMixedQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int _mode = _random.Next(1, 5);
            _questions.Add(_mode switch
            {
                1 => EasyQuestionsSum.ElementAt(_random.Next(EasyQuestionsSum.Count())),
                2 => EasyQuestionsSubtraction.ElementAt(_random.Next(EasyQuestionsSubtraction.Count())),
                3 => EasyQuestionsMultiplication.ElementAt(_random.Next(EasyQuestionsMultiplication.Count())),
                4 => EasyQuestionsDivision.ElementAt(_random.Next(EasyQuestionsDivision.Count())),
            });
        }
        return _questions;
    }

    internal static IEnumerable<Question> MediumDifficultyMixedQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int _mode = _random.Next(1, 5);
            _questions.Add(_mode switch
            {
                1 => MediumQuestionsSum.ElementAt(_random.Next(MediumQuestionsSum.Count())),
                2 => MediumQuestionsSubtraction.ElementAt(_random.Next(MediumQuestionsSubtraction.Count())),
                3 => MediumQuestionsMultiplication.ElementAt(_random.Next(MediumQuestionsMultiplication.Count())),
                4 => MediumQuestionsDivision.ElementAt(_random.Next(MediumQuestionsDivision.Count())),
            });
        }
        return _questions;
    }

    internal static IEnumerable<Question> HardDifficultyMixedQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int _mode = _random.Next(1, 5);
            _questions.Add(_mode switch
            {
                1 => HardQuestionsSum.ElementAt(_random.Next(HardQuestionsSum.Count())),
                2 => HardQuestionsSubtraction.ElementAt(_random.Next(HardQuestionsSubtraction.Count())),
                3 => HardQuestionsMultiplication.ElementAt(_random.Next(HardQuestionsMultiplication.Count())),
                4 => HardQuestionsDivision.ElementAt(_random.Next(HardQuestionsDivision.Count())),
            });
        }
        return _questions;
    }

    internal static IEnumerable<Question> RandomDifficultyMixedQuestions()
    {
        Random _random = new Random();
        List<Question> _questions = new List<Question>();
        for (int i = 0; i < 5; i++)
        {
            int _mode = _random.Next(1, 5);
            int _difficulty = _random.Next(1, 4);
            _questions.Add((_mode, _difficulty) switch
            {
                (1, 1) => EasyQuestionsSum.ElementAt(_random.Next(EasyQuestionsSum.Count())),
                (1, 2) => MediumQuestionsSum.ElementAt(_random.Next(MediumQuestionsSum.Count())),
                (1, 3) => HardQuestionsSum.ElementAt(_random.Next(HardQuestionsSum.Count())),
                (2, 1) => EasyQuestionsSubtraction.ElementAt(_random.Next(EasyQuestionsSubtraction.Count())),
                (2, 2) => MediumQuestionsSubtraction.ElementAt(_random.Next(MediumQuestionsSubtraction.Count())),
                (2, 3) => HardQuestionsSubtraction.ElementAt(_random.Next(HardQuestionsSubtraction.Count())),
                (3, 1) => EasyQuestionsMultiplication.ElementAt(_random.Next(EasyQuestionsMultiplication.Count())),
                (3, 2) => MediumQuestionsMultiplication.ElementAt(_random.Next(MediumQuestionsMultiplication.Count())),
                (3, 3) => HardQuestionsMultiplication.ElementAt(_random.Next(HardQuestionsMultiplication.Count())),
                (4, 1) => EasyQuestionsDivision.ElementAt(_random.Next(EasyQuestionsDivision.Count())),
                (4, 2) => MediumQuestionsDivision.ElementAt(_random.Next(MediumQuestionsDivision.Count())),
                (4, 3) => HardQuestionsDivision.ElementAt(_random.Next(HardQuestionsDivision.Count())),
            });
        }
        return _questions;
    }
}
