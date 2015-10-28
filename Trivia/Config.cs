using System.IO;
using Newtonsoft.Json;
using TShockAPI;

namespace Trivia
{
    public class Config
    {
        public static string SavePath = Path.Combine(TShock.SavePath, "Trivia.json");
        public bool Enabled = true;
        public int QuestionInterval = 60;
        public int AnswerTime = 15;
        public bool DisplayWrongAnswers = false;
        public int CurrencyAmount = 25;
        public QAndA[] QuestionsAndAnswers;

        public Config()
        {
            Initialize();
        }

        public Config(string path) : this()
        {
            if (!File.Exists(SavePath))
                write();
            else
                Read();
        }

        public bool Read()
        {
            try
            {               
                Config res = JsonConvert.DeserializeObject<Config>(File.ReadAllText(SavePath));
                this.Enabled = res.Enabled;
                this.QuestionInterval = res.QuestionInterval;
                this.AnswerTime = res.AnswerTime;
                this.DisplayWrongAnswers = res.DisplayWrongAnswers;
                this.CurrencyAmount = res.CurrencyAmount;
                this.QuestionsAndAnswers = res.QuestionsAndAnswers;
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void write()
        {
            File.WriteAllText(SavePath, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public void Reload(CommandArgs args)
        {
            if (Read())
                args.Player.SendSuccessMessage("Trivia config reloaded sucessfully.");

            else
                args.Player.SendErrorMessage("Trivia config reloaded unsuccessfully. Copy-paste your config into www.jsonlint.com for details.");
        }

        public void Initialize()
        {
            QuestionsAndAnswers = new QAndA[]
            {
                new QAndA("You kill vegetarian vampires with a _____ to the heart.","steak"),
                new QAndA("Why can't you hear a pterodactyl go to the bathroom? Because the P is _____","silent"),
                new QAndA("How did the hipster burn his tongue? He drank his coffee before it was ____","cool"),
                new QAndA("Two peanuts walk into a bar, and one was a ______","salted"),
                new QAndA("My geometry teacher had an accident today. He sprained his ____.","angle"),
                new QAndA("What do you call a fly without wings or legs?","a roll"),
                new QAndA("C, E Flat, and G walk into a bar. The bartender says; Sorry, no ______.","minors"),
                new QAndA("Here, have a dead battery. ____ of ______.","free charge"),
                new QAndA("What do you call two crows?","attempted murder"),
                new QAndA("Why isn't there and gambling in Africa? Because there're too many _______.","cheetahs"),
                new QAndA("The best way to stop a charging bull is to take away his _____ ____.","credit card"),
                new QAndA("They should make a Minecraft movie, it would be a _______.","blockbuster"),
                new QAndA("What do sea monsters eat for lunch? ____ and _____.","fish ships"),
                new QAndA("Why was Cinderella thrown off the basketball team? She always ran away from the ____.","ball"),
                new QAndA("I'm emotionally constipated. I haven't given a ____ in days.","shit"),
                new QAndA("I can't believe I got fired from the calendar factory. All I did was take a ____ ___.","day off"),
                new QAndA("Watt is love? Baby don't ____ me!","hertz"),
                new QAndA("Which is the only U.S. state that officially grows coffee?","hawaii"),
                new QAndA("What was Mickey Mouse’s name before it was changed to Mickey?","mortimer"),
                new QAndA("Doritos are red, Illuminati has triangles. The government has fallen, and is run by ________.","reptiles"),
                new QAndA("Why didn't the chicken cross the road? Because it was ____.","dead"),
                new QAndA("I lost an electron. Are you _______?","positive"),
                new QAndA("If 666 is all evil, is ______ the root of all evil?","25.8069"),
                new QAndA("He threw sodium chloride at me! That's a ____.","salt"),
                new QAndA("What's the biggest advantage of living in Switzerland? Well, the flag is a big ____.","plus"),
                new QAndA("All roses are red; And all violets are blue; Shit, that's a _____","haiku"),
                new QAndA("What do you call a wingless fly?","a walk"),
                new QAndA("Why are there walls around a cemetery? Because people are _____ to get in.","dying"),
                new QAndA("Bought some velcro today. It's a ___ ___","rip off"),
                new QAndA("How does the moon cut it's hair? _______ it.","eclipse"),
                new QAndA("How do you make an egg-roll? You ____ it.","push"),
                new QAndA("My dad almost told me a joke about pizza. But it was too _____","cheesy"),
                new QAndA("The boiled water died, it shall be ____.","mist"),
                new QAndA("If a clock gets hungry, it goes back ____ _____.","four seconds"),
                new QAndA("Once you've seen one shopping center, you've seen ___ ____","the mall"),
                new QAndA("Santa's helpers are ___________ clauses.","subordinate"),
                new QAndA("Acupuncture is a ___ well done.","jab"),
                new QAndA("Jumping off a Paris bridge makes you in _____","seine"),
                new QAndA("Bakers trade recipes on a _____ to know basis.","knead"),
                new QAndA("A backwards poet write _______","inverse"),
                new QAndA("I would like to make a pun about philosophy, but i ____","kant"),
                new QAndA("If Iron Man and Silver Surfer team up, they would be ______","alloys"),
                new QAndA("I went to a seafood disco last week. I pulled a ______","mussel"),
                new QAndA("What do you get when you toss a hand grenade into a kitchen in France?","linoleum blownapart"),
                new QAndA("A made a new belt from watches. It's a _____ of ____!","waist time"),
                new QAndA("Why can't a nose be 12 inches long? Because then it would be a ____!","foot"),
                new QAndA("Why did the tomato blush? Because it saw the salad ________.","dressing"),
                new QAndA("A plateau is a high form of _______.","flattery"),
                new QAndA("If you don't pay your exorcist you get _________","repossessed"),
                new QAndA("A chicken crossing the road is ______ in motion.","poultry"),
                new QAndA("If you can't choose between an angry psychic and a sad psychic, you'll have to find a _____ _____.","happy medium"),
                new QAndA("Did you hear about the guy whose whole left side was cut off? He's ___ _____ now.","all right"),
                new QAndA("I'm reading a book about anti-gravity. It's impossible to ___ ____.","put down"),
                new QAndA("I used to be a banker but I lost _______.","interest"),
                new QAndA("I wasn't originally going to get a brain transplant, but then I ______ my ____.","changed mind"),
                new QAndA("Claustrophobic people are more productive thinking _______ the ___.","outside box"), 
                new QAndA("A man just assaulted me with milk, cream and butter. How _____.","dairy"),
                new QAndA("Have you ever tried to eat a clock? It's very time ________.","consuming"),
                new QAndA("He drove his expensive car into a tree and found out how the Mercedes _____.","bends"),
                new QAndA("Police were called to a daycare where a three-year-old was resisting _ ____.","a rest"),
                new QAndA("The man who survived mustard gas and pepper spray is now a ________ veteran.","seasoned"),
                new QAndA("I'm glad I know sign language, it's pretty _____.","handy"),
                new QAndA("I don't trust these stairs because they're always __ __ something.","up to"),            
                new QAndA("When Peter Pan punches, they _______.","neverland"), 
                new QAndA("A new type of broom came out, it is ______ the nation.","sweeping"), 
            };
        }
    }
}
