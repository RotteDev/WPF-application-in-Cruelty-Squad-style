using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class DivineView : UserControl
    {
        private class Question
        {
            public string Text;
            public string[] Answers;
            public int CorrectIndex;
        }

        private readonly List<Question> _allQuestions = new List<Question>
        {
            new Question {
                Text = "WHEN YOU LOOK AT THE SUNSET OVER THE SWAMP, YOU SEE:",
                Answers = new[] {
                    "PRISTINE NATURAL PURITY AND THE FADING LIGHT OF DEPARTING DAY.",
                    "A SET OF PIXELS, DISTORTED GEOMETRY AND RUSTY TEXTURES.",
                    "AN ORDINARY CHANGE OF TIME OF DAY, EVOKING NO EMOTIONS." },
                CorrectIndex = 0 },

            new Question {
                Text = "HAVE YOU EVER HEARD A PURE, NATURAL BELL RING IN ABSOLUTE SILENCE?",
                Answers = new[] {
                    "YES, THIS SOUND BRINGS ME DEEP MENTAL PEACE AND CLARITY.",
                    "NO, IN SILENCE I HEAR ONLY LOW-FI HUM, WHITE NOISE OR SCRAPING METAL.",
                    "SOMETIMES I HEAR RINGING IN MY EARS, BUT I ATTRIBUTE IT TO NORMAL PRESSURE." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHAT DOES WHITE COLOR IN THE SURROUNDING SPACE ASSOCIATE WITH FOR YOU?",
                Answers = new[] {
                    "ABSOLUTE PURITY, HOLINESS AND VIRGINITY OF MIND.",
                    "STERILITY OF HOSPITAL WARDS, BONES AND EMPTINESS AFTER LIQUIDATION.",
                    "JUST ONE OF THE BASIC COLORS OF THE SPECTRUM." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU NOTICE THAT THE GEOMETRY OF THE WALLS IN YOUR ROOM SEEMS PERFECTLY EVEN AND STABLE?",
                Answers = new[] {
                    "YES, THE SPACE AROUND ME IS MOTIONLESS, HARMONIOUS AND PREDICTABLE.",
                    "NO, THE WALL TEXTURES CONSTANTLY FLOAT, JITTER OR SEEM TORN.",
                    "I DON'T PAY ATTENTION TO WALLS IF THEY DON'T INTERFERE WITH MY ACTIVITIES." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHAT FEELING DOES THE SIGHT OF CLEAN, TRANSPARENT RUNNING WATER EVOKE IN YOU?",
                Answers = new[] {
                    "A SINCERE DESIRE TO CLEANSE MYSELF, WASH OFF THE DIRT AND FEEL FRESH.",
                    "SUSPICION THAT IT IS POISONED WITH TOXINS OR LIQUID BIOMASS.",
                    "WATER IS JUST A MEANS TO QUENCH THIRST AND MAINTAIN HYDRATION." },
                CorrectIndex = 0 },

            new Question {
                Text = "DOES THE WORLD AROUND YOU EVER SUDDENLY SEEM LIKE AN ARTIFICIAL, DIRTY DECORATION?",
                Answers = new[] {
                    "NEVER, THE WORLD AROUND ME IS REAL, FULL OF LIFE AND DEEP MEANING.",
                    "CONSTANTLY, I FEEL TRAPPED INSIDE AN UGLY PIXEL NIGHTMARE.",
                    "RARELY, ONLY IN MOMENTS OF SEVERE FATIGUE OR LACK OF SLEEP." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHEN YOU CLOSE YOUR EYES, YOU SEE:",
                Answers = new[] {
                    "CALM, CLEAN DARKNESS BRINGING LONG-AWAITED RELAXATION.",
                    "FLASHES OF ACID COLORS, IMAGES OF RAW MEAT AND CHAOTIC SPOTS.",
                    "ORDINARY GRAY SILHOUETTES AND RESIDUAL CONTOURS OF OBJECTS." },
                CorrectIndex = 0 },

            new Question {
                Text = "ARE YOU CAPABLE OF SINCERELY REJOICING AT THE BIRTH OF A LIVING BEING (E.G., A BIRD OR ANIMAL)?",
                Answers = new[] {
                    "YES, IT IS A GREAT MIRACLE OF LIFE AND A MANIFESTATION OF PRISTINE NATURE.",
                    "NO, IT IS JUST THE APPEARANCE OF A NEW PIECE OF FLESH DOOMED TO ROT.",
                    "IT IS AN ORDINARY BIOLOGICAL PROCESS OF CARBON COMPOUND REPRODUCTION." },
                CorrectIndex = 0 },

            new Question {
                Text = "SOUNDS OF NATURE (RAIN, RUSTLING GRASS) EVOKE IN YOU:",
                Answers = new[] {
                    "A FEELING OF UNITY WITH THE WORLD AND DEEP INNER PEACE.",
                    "IRRITATION, AS THEY DROWN OUT IMPORTANT TACTICAL NOISES.",
                    "I PERCEIVE THEM AS A BACKGROUND AUDIO STREAM OF NO SIGNIFICANCE." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU BELIEVE THE HUMAN MIND IS BORN PURE AND SINLESS?",
                Answers = new[] {
                    "YES, EVERY PERSON COMES INTO THIS WORLD TO CREATE AND CARRY LIGHT.",
                    "NO, WE ARE BORN SLAVES TO OUR BIOLOGICAL NEEDS AND FEAR OF DEATH.",
                    "THE MIND IS A BLANK SLATE FILLED WITH RANDOM ENVIRONMENTAL EXPERIENCE." },
                CorrectIndex = 0 },

            new Question {
                Text = "HOW DO YOU FEEL ABOUT REPLACING YOUR HEALTHY BIOLOGICAL EYES WITH MECHANICAL SENSORS?",
                Answers = new[] {
                    "WITH SHARP DISGUST, MY BODY MUST REMAIN PURE FROM ALIEN IRON.",
                    "POSITIVELY, IF IT INCREASES MY ACCURACY AND LETS ME SEE TARGETS IN THE DARK.",
                    "NEUTRALLY, IT IS JUST A MEDICAL PROCEDURE FOR EFFICIENCY." },
                CorrectIndex = 0 },

            new Question {
                Text = "HAVE YOU NOTICED RECENTLY THAT YOUR SKIN CHANGES ITS STRUCTURE OR COLOR?",
                Answers = new[] {
                    "NO, MY SKIN IS ABSOLUTELY HEALTHY, NATURAL AND UNCHANGING.",
                    "YES, STRANGE PIXEL SPOTS, GROWTHS OR A ROTTEN SMELL APPEAR ON IT.",
                    "THERE ARE MINOR DEFECTS, BUT THESE ARE NORMAL EFFECTS OF THE HARSH SWAMP CLIMATE." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHAT DOES THE CONCEPT OF \"IDEAL BODY\" MEAN TO YOU?",
                Answers = new[] {
                    "A CLEAN, HEALTHY BIOLOGICAL SHELL, UNTAINTED BY MUTATIONS.",
                    "A MAXIMALLY AUGMENTED BIOMECHANICAL SUIT WITH LOTS OF WEAPONS.",
                    "A SHELL CAPABLE OF PERFORMING ITS FUNCTIONS WITHOUT FREQUENT BREAKDOWNS." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU FEAR THAT ALIEN TISSUES MAY DEVELOP INSIDE YOUR BODY?",
                Answers = new[] {
                    "YES, THE THOUGHT THAT MY FLESH MAY MUTATE AND ROT TERRIFIES ME.",
                    "NO, ANY FLESH MUTATION IS JUST AN ADAPTATION TO THE HARSH MARKET REALITY.",
                    "IT WORRIES ME ONLY IF IT REDUCES MY OVERALL ENDURANCE." },
                CorrectIndex = 0 },

            new Question {
                Text = "IF YOU WERE OFFERED AN IMPLANT THAT COMPLETELY DISABLES PHYSICAL PAIN, WOULD YOU AGREE?",
                Answers = new[] {
                    "NO, PAIN IS A NATURAL SIGNAL OF THE BODY HELPING PRESERVE HUMANITY.",
                    "YES, PAIN ONLY DISTRACTS FROM GRINDING AND HINDERS TASKS.",
                    "ONLY IF THIS IMPLANT DOES NOT CONSUME TOO MUCH BODY ENERGY." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU FEEL AS ONE WITH YOUR PHYSICAL BODY?",
                Answers = new[] {
                    "ABSOLUTELY, I TREAT MY FLESH WITH CARE AND RESPECT ITS BOUNDARIES.",
                    "NO, MY BODY SEEMS UGLY, ALIEN AND A TEMPORARY MECHANISM.",
                    "I PERCEIVE THE BODY AS A TOOL THAT NEEDS PERIODIC MAINTENANCE." },
                CorrectIndex = 0 },

            new Question {
                Text = "THE SIGHT OF EXPOSED HUMAN MUSCLES, BONES AND INTERNAL ORGANS EVOKES IN YOU:",
                Answers = new[] {
                    "DEEP SHOCK, COMPASSION FOR OTHERS' PAIN AND EXISTENTIAL FEAR.",
                    "INDIFFERENCE OR PRAGMATIC INTEREST IN THE VALUE OF THIS BIOMASS.",
                    "ANATOMICAL INTEREST RELATED TO UNDERSTANDING THE ENEMY'S VULNERABLE ZONES." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU STRIVE TO MAINTAIN THE PURITY OF YOUR DIET, AVOIDING QUESTIONABLE GRAY SLUDGE AND BIO-CANS?",
                Answers = new[] {
                    "YES, I TRY TO EAT ONLY CLEAN, NATURAL AND SAFE FOOD.",
                    "NO, I AM READY TO EAT ANY SYNTHETIC GLUE IF IT IS CHEAP AND GIVES CALORIES.",
                    "I EAT WHAT IS AVAILABLE IN MY SECTOR WITHOUT THINKING ABOUT ITS ORIGIN." },
                CorrectIndex = 0 },

            new Question {
                Text = "DOES THE THOUGHT THAT AFTER DEATH YOUR CONSCIOUSNESS MAY BE FORCIBLY DIGITIZED AND LOCKED IN A ROBOT CAUSE YOU:",
                Answers = new[] {
                    "HORROR, IT IS A DESECRATION OF THE SOUL AND DEPRIVATION OF SACRED DEATH.",
                    "JOY, BECAUSE IT IS A GREAT WAY TO GAIN IMMORTALITY AND CONTINUE WORKING.",
                    "I DON'T CARE IN WHAT FORM MY MIND WILL EXIST AFTER DEATH." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU BELIEVE THAT FORCED CHANGE OF HUMAN GENETIC CODE IS A CRIME AGAINST NATURE?",
                Answers = new[] {
                    "YES, IT IS A GROSS VIOLATION OF THE PRISTINE PURITY AND VIRGINITY OF THE SPECIES.",
                    "NO, IT IS A NECESSARY OPTIMIZATION OF HUMAN CATTLE FOR EVOLUTION.",
                    "IT IS AN ORDINARY STEP IN TECHNOLOGICAL DEVELOPMENT WITH PROS AND CONS." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHAT FIRST COMES TO YOUR MIND AT THE WORD \"DEATH\"?",
                Answers = new[] {
                    "SACRED PEACE, THE END OF THE EARTHLY PATH AND RETURN TO THE ORIGINS OF LIGHT.",
                    "A PROFITABLE INVESTMENT, LIQUIDATION OF ASSETS OR LOSS OF WORKING TIME.",
                    "THE NATURAL BIOLOGICAL END OF ANY LIVING ORGANISM ON THIS EARTH." },
                CorrectIndex = 0 },

            new Question {
                Text = "ARE YOU CAPABLE OF COMPASSION FOR A STRANGER WHO HAS LOST EVERYTHING AND ASKS FOR HELP?",
                Answers = new[] {
                    "YES, OTHERS' SUFFERING EVOKES IN ME A SINCERE DESIRE TO HELP AND COMFORT.",
                    "NO, THE WEAK AND ILLIQUID UNITS MUST BE RECYCLED BY THE MARKET.",
                    "I SYMPATHIZE WITH HIM, BUT I WILL NOT SPEND MY RESOURCES ON OTHERS' PROBLEMS." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU BELIEVE THAT SINCERE LOVE, FIDELITY AND SELFLESS FRIENDSHIP STILL EXIST IN THIS WORLD?",
                Answers = new[] {
                    "YES, THESE FEELINGS ARE SACRED, THEY KEEP OUR MINDS FROM FALLING INTO DARKNESS.",
                    "NO, THEY ARE HORMONAL HALLUCINATIONS CREATING TRANSACTION COSTS.",
                    "THEY ARE USEFUL SOCIAL CONSTRUCTS HELPING PEOPLE UNITE INTO GROUPS." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHEN YOU HEAR THE MONOTONOUS, ROBOTIC VOICE OF THE SYSTEM ANNOUNCING ANOTHER SECTOR PURGE, YOU FEEL:",
                Answers = new[] {
                    "DEEP SORROW AT THE DEVALUATION OF LIVES AND TOTAL CYNICISM OF THE WORLD.",
                    "A RUSH OF ADRENALINE AND A DESIRE TO IMMEDIATELY JOIN THE PROFIT AUDIT.",
                    "ORDINARY INDIFFERENCE, IT IS STANDARD NEWS OF MY ADMINISTRATIVE BLOCK." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU BELIEVE THAT MURDER FOR MONEY CAN BE JUSTIFIED BY \"PROFESSIONAL NECESSITY\"?",
                Answers = new[] {
                    "NEVER, TAKING LIFE FOR PROFIT IS THE GRAVEST SIN, DEFILING THE SOUL.",
                    "ABSOLUTELY, MURDER IS JUST A TRANSACTION, A JOB CLEANSING THE MARKET OF ILLIQUID.",
                    "IT IS A NECESSARY EVIL IN A WILD WORLD WHERE EVERYONE SURVIVES AS THEY CAN." },
                CorrectIndex = 0 },

            new Question {
                Text = "WHAT MEMORIES DOES THE CONCEPT OF \"FAMILY\" EVOKE IN YOU?",
                Answers = new[] {
                    "WARMTH, SAFETY, PARENTAL HOME AND MOMENTS OF SINCERE HAPPINESS.",
                    "A BURDEN THAT HINDERS ROUND-THE-CLOCK GRINDING AND WASTES MY BIO-CREDITS.",
                    "A GROUP OF RELATIVES WITH WHOM I MAINTAIN CONTACT AS NEEDED." },
                CorrectIndex = 0 },

            new Question {
                Text = "IF YOU COULD RETURN TO THE PAST, WHEN THE WORLD WAS NOT YET SOAKED IN CYNICISM, WOULD YOU?",
                Answers = new[] {
                    "YES, I WOULD GIVE ANYTHING TO RESTORE THAT PRISTINE PURITY AND PEACE OF MIND.",
                    "NO, THAT PAST WAS INEFFICIENT, WEAK AND ECONOMICALLY UNDERDEVELOPED.",
                    "UNLIKELY, BECAUSE THERE I WOULD NOT HAVE MY CURRENT SKILLS AND EQUIPMENT." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU FEEL DISGUST WHEN A PROGRAM AUTOMATICALLY ERASES YOUR PERSONAL THOUGHTS, REPLACING THEM WITH SLOGANS?",
                Answers = new[] {
                    "YES, IT IS VIOLENCE AGAINST MY PERSONALITY AND AN ATTEMPT TO TURN ME INTO A SOULLESS AUTOMATON.",
                    "NO, I AM GRATEFUL TO THE SYSTEM FOR CLEANSING MY SYNAPSES OF DESTRUCTIVE TRASH.",
                    "IT IS A BIT ANNOYING, BUT I AM USED TO ADAPTING TO SOFTWARE RULES." },
                CorrectIndex = 0 },

            new Question {
                Text = "IN THE FACE OF INEVITABLE DEATH, THE MOST IMPORTANT THING FOR YOU IS:",
                Answers = new[] {
                    "TO PRESERVE THE VIRGIN PURITY OF MY SOUL, MEETING DEATH WITHOUT FEAR AND MALICE.",
                    "TO LOCK IN MAXIMUM PROFIT AND DAMAGE COMPETITORS.",
                    "TO TRY TO USE ALL AVAILABLE MEDICATIONS TO POSTPONE THE END." },
                CorrectIndex = 0 },

            new Question {
                Text = "DO YOU CONSIDER YOURSELF A PERSON WHO HAS MANAGED TO PRESERVE INNER LIGHT DESPITE THE SURROUNDING MADNESS?",
                Answers = new[] {
                    "YES, I TRY WITH ALL MY MIGHT TO RETAIN MY HUMANITY, PURITY AND INNOCENCE OF SPIRIT.",
                    "NO, I BECAME PART OF THIS ROTTING, CYNICAL AND PRAGMATIC REALITY LONG AGO.",
                    "I DON'T THINK ABOUT METAPHYSICS, I JUST DO MY DAILY TASKS." },
                CorrectIndex = 0 },
        };

        private MainScreen _mainScreen;
        private List<Question> _shuffledQuestions;
        private int _currentIndex = 0;
        private int _correctCount = 0;

        private DispatcherTimer _timer;
        private double _maxTimerWidth = 560;
        private readonly TimeSpan _questionTime = TimeSpan.FromSeconds(10);
        private DateTime _questionStartTime;

        private CheckBox _selectedCheckBox;

        public DivineView(MainScreen mainScreen)
        {
            InitializeComponent();
            _mainScreen = mainScreen;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("DivineTestStart.mp3");

            IntroPanel.Visibility = Visibility.Collapsed;
            TestPanel.Visibility = Visibility.Visible;

            if (_mainScreen != null)
                _mainScreen.IsCloseLocked = true;

            var rnd = new Random();
            _shuffledQuestions = _allQuestions.OrderBy(x => rnd.Next()).ToList();
            _currentIndex = 0;
            _correctCount = 0;

            LoadQuestion();
        }

        private void LoadQuestion()
        {
            if (_currentIndex >= _shuffledQuestions.Count)
            {
                ShowResult();
                return;
            }

            _selectedCheckBox = null;
            NextButton.IsEnabled = false;

            var q = _shuffledQuestions[_currentIndex];
            QuestionText.Text = q.Text;

            AnswersPanel.Children.Clear();

            var rnd = new Random();
            var indexes = Enumerable.Range(0, q.Answers.Length).OrderBy(x => rnd.Next()).ToArray();

            string[] labels = { "A", "B", "C" };

            for (int i = 0; i < indexes.Length; i++)
            {
                int idx = indexes[i];
                string label = labels[i];

                var textBlock = new TextBlock
                {
                    Text = $"{label}) {q.Answers[idx]}",
                    FontFamily = (FontFamily)FindResource("MingLiUFont"),
                    FontSize = 14,
                    Foreground = Brushes.Black,
                    TextWrapping = TextWrapping.Wrap
                };

                var cb = new CheckBox
                {
                    Content = textBlock,
                    Margin = new Thickness(0, 5, 0, 5),
                    Tag = idx,
                    VerticalAlignment = VerticalAlignment.Top,
                    MaxWidth = 540
                };

                cb.Checked += CheckBox_Checked;
                cb.Unchecked += CheckBox_Unchecked;

                AnswersPanel.Children.Add(cb);
            }

            _questionStartTime = DateTime.Now;
            TimerBar.Width = _maxTimerWidth;

            if (_timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = TimeSpan.FromMilliseconds(50);
                _timer.Tick += Timer_Tick;
            }

            _timer.Start();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb == null) return;

            _selectedCheckBox = cb;

            foreach (var child in AnswersPanel.Children)
            {
                if (child is CheckBox other && other != cb)
                    other.IsChecked = false;
            }

            NextButton.IsEnabled = true;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            bool anyChecked = AnswersPanel.Children.OfType<CheckBox>().Any(c => c.IsChecked == true);
            NextButton.IsEnabled = anyChecked;
            if (!anyChecked) _selectedCheckBox = null;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - _questionStartTime;
            double remaining = 1.0 - (elapsed.TotalSeconds / _questionTime.TotalSeconds);

            if (remaining <= 0)
            {
                TimerBar.Width = 0;
                NextQuestion();
                return;
            }

            TimerBar.Width = _maxTimerWidth * remaining;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCheckBox == null) return;

            SoundManager.Play("DivineTestAgree.mp3");

            var q = _shuffledQuestions[_currentIndex];
            int chosenIndex = (int)_selectedCheckBox.Tag;

            if (chosenIndex == q.CorrectIndex)
                _correctCount++;

            NextQuestion();
        }

        private void NextQuestion()
        {
            if (_timer != null) _timer.Stop();
            _currentIndex++;
            LoadQuestion();
        }

        private void ShowResult()
        {
            TestPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Visible;

            double percent = (double)_correctCount / _shuffledQuestions.Count;

            if (percent >= 0.7)
            {
                ResultText.Foreground = Brushes.Green;
                ResultText.Text = $"YOU HAVE ASCENDED.\n\nCORRECT ANSWERS: {_correctCount} / {_shuffledQuestions.Count}\n\nWELCOME TO THE DIVINE LIGHT.";

                _mainScreen?.ApplyUI(3);
            }
            else if (percent >= 0.4)
            {
                ResultText.Foreground = Brushes.Black;
                ResultText.Text = $"PARTIAL ACCEPTANCE.\n\nCORRECT ANSWERS: {_correctCount} / {_shuffledQuestions.Count}\n\nTHE LIGHT REMAINS UNDECIDED.";

                _mainScreen?.ApplyUI(2);
            }
            else
            {
                ResultText.Foreground = Brushes.Red;
                ResultText.Text = $"YOU ARE NOT WORTHY OF THE DIVINE LIGHT.\n\nCORRECT ANSWERS: {_correctCount} / {_shuffledQuestions.Count}\n\nYOUR FLESH WILL BE DEGRADED.";

                _mainScreen?.ApplyUI(1);
            }

            if (_mainScreen != null)
                _mainScreen.IsCloseLocked = false;
        }

        public void OnClosed()
        {
            if (_timer != null) _timer.Stop();

            if (_mainScreen != null)
                _mainScreen.IsCloseLocked = false;
        }
    }
}