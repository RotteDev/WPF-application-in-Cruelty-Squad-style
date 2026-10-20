using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class MentalWearView : UserControl
    {
        private class Question
        {
            public string Text;
            public string ImageFile;
            public string[] Answers;
            public int CorrectIndex;
        }

        private readonly List<Question> _allQuestions = new List<Question>
{
    new Question {
        Text = "RATE YOUR DEGREE OF SYNERGY WITH THE CORPORATE SWARM.",
        ImageFile = "MentalTestIcon1",
        Answers = new[] {
            "I BUILD FRIENDLY RELATIONS WITH COLLEAGUES.",
            "I USE THEIR BIO-MASS TO OPTIMIZE MY TASKS.",
            "I AVOID CONTACT DUE TO EXISTENTIAL FEAR." },
        CorrectIndex = 1 },

    new Question {
        Text = "DOES BIOLOGICAL LIQUIDATION DURING WORK HOURS CAUSE YOU PANIC?",
        ImageFile = "MentalTestIcon2",
        Answers = new[] {
            "YES, I WANT TO LIVE AND RETURN TO MY FAMILY.",
            "NO, DEATH IS THE FINAL INVESTMENT IN THE CONSUMER SOFTPRODUCTS ECONOMY.",
            "I ONLY FEAR EQUIPMENT DOWNTIME DURING MY DEATH." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT ARE THE TASTE CHARACTERISTICS OF THE LIQUID BIO-ASSET IN YOUR SHELL?",
        ImageFile = "MentalTestIcon3",
        Answers = new[] {
            "GLANDULAR, SALTY, METALLIC.",
            "THE TASTE OF PURE PROFIT AND LIQUIDITY.",
            "BITTER TASTE OF UNPAID CORPORATE DEBT." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT DO YOUR OPTICAL SENSORS CAPTURE IN THIS RENDERING SECTOR?",
        ImageFile = "MentalTestIcon4",
        Answers = new[] {
            "FINGERS REACHING FROM DARKNESS, TOWERS WITH RED LIGHTS IN FOG.",
            "GROWTH DYNAMICS OF PURE PROFIT AND CONSUMER SOFTPRODUCTS CELL TOWERS.",
            "PANIC SIGNALS OF FADING SYNAPSES IN MY SKULL." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT CORPORATE DIRECTIVE DOES THIS VISUAL PATTERN EVOKE?",
        ImageFile = "MentalTestIcon5",
        Answers = new[] {
            "VIOLATION OF CIVIL RIGHTS, POLICE TYRANNY AND OPPRESSION.",
            "URBAN SPACE OPTIMIZATION BY THE DEPARTMENT OF ORDER CULT.",
            "UNAUTHORIZED DISPOSAL OF LIQUID BIO-ASSETS ON THE ROADWAY." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT STANDARD EFFICIENCY TOOL DO YOU OBSERVE ON SCREEN?",
        ImageFile = "MentalTestIcon6",
        Answers = new[] {
            "A STRANGE TRANSLUCENT SKULL OR ALIEN MASK.",
            "A CONSUMER SOFTPRODUCTS TACTICAL LIQUIDATOR HELMET WITH TRIPLE OPTICAL SENSOR.",
            "FROZEN BIO-MASS READY FOR IMMEDIATE EXCHANGE TRANSPORT." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOUR NEURORECEPTORS REGISTER A DESTRUCTIVE FEAR IMPULSE FROM THIS LIQUIDATOR?",
        ImageFile = "MentalTestIcon7",
        Answers = new[] {
            "YES, THIS FLESH-COVERED KILLER WITH A WEAPON LOOKS TERRIFYING.",
            "NO, THIS IS A HIGHLY EFFECTIVE CORPORATE AUDIT TOOL READY TO PURGE ILLIQUID.",
            "MY ONLY FEAR IS IF HE LIQUIDATES ME BEFORE I CLOSE THE REPORT." },
        CorrectIndex = 1 },

    new Question {
        Text = "DOES YOUR GRINDSET ALLOW BIOLOGICAL RECYCLING AT THE PEAK OF THE HIERARCHY?",
        ImageFile = "MentalTestIcon8",
        Answers = new[] {
            "NO, I WANT TO RETIRE AND LIVE PEACEFULLY AWAY FROM THE MARKET.",
            "YES, FALLING BY A MERCENARY'S HAND AS A CEO IS THE HIGHEST TRANSACTION.",
            "MY FLESH WILL DISSOLVE IN CORPORATE CODE LONG BEFORE I'M ORDERED." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT MARKET OPERATION ARE THESE COMBAT UNITS PERFORMING RIGHT NOW?",
        ImageFile = "MentalTestIcon9",
        Answers = new[] {
            "THEY FEEL PLATONIC AFFECTION AND LOVE EACH OTHER.",
            "THEY PERFORM TACTILE CALIBRATION OF BODY ARMOR BEFORE PURGING ILLIQUID.",
            "THE LEFT UNIT EXTRACTS THE RIGHT'S LIQUID SPLEEN FOR SALE." },
        CorrectIndex = 1 },

    new Question {
        Text = "DOES YOUR BIOLOGICAL SHELL REQUIRE HIGH-THERMAL ZONES FOR RELAXATION?",
        ImageFile = "MentalTestIcon10",
        Answers = new[] {
            "YES, I DREAM OF FLYING TO THE SEA AND RESTORING MY STRENGTH.",
            "NO, THE BEST CLIMATE ZONE IS A SEALED WORK CAPSULE WITH NUTRIENT GLUE.",
            "MY FLESH DECOMPOSES WELL EVEN UNDER THE SWAMP'S SCORCHING SUN." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOUR AESTHETIC SENSORS REGISTER DISGUST TOWARD THIS RAW MATERIAL?",
        ImageFile = "MentalTestIcon11",
        Answers = new[] {
            "YES, THIS FLAYED MEAT AND BARE SKULL LOOK DISGUSTING.",
            "NO, THIS IS HIGHLY EFFECTIVE, SKIN-CLEANSED BIO-MASS READY FOR EXCHANGE.",
            "ONLY THE FACT THAT THIS FLESH IDLES WITHOUT GENERATING PROFIT DISGUSTS ME." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT UTILITARIAN FUNCTION DOES THIS DRAINAGE NODE SERVE?",
        ImageFile = "MentalTestIcon12",
        Answers = new[] {
            "AN OPENING FOR BASE DESTRUCTIVE SEXUAL NEEDS.",
            "THE MAIN LOGISTICS ARTERY OF CONSUMER SOFTPRODUCTS FOR DRAINING TOXIC LIQUIDITY.",
            "A HOLE BLEEDING ILLIQUID REMAINS OF LIQUIDATED JUNIOR MANAGERS." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOU TRUST OUR DEPARTMENT OF SECURITY?",
        ImageFile = "MentalTestIcon13",
        Answers = new[] {
            "NO, THEY LOOK LIKE SOULLESS MUTANTS WITH WEAPONS WHO MAIM CITIZENS.",
            "YES, THEY ARE FLAWLESSLY OPTIMIZED ORGANIC MACHINES FOR MARKET STABILITY.",
            "THEIR QUALIFICATIONS ARE EXCESSIVE — ANY TERRORIST IS AN UNREALIZED BIO-RESOURCE." },
        CorrectIndex = 1 },

    new Question {
        Text = "DOES THIS COORDINATE MARKER ON YOUR SHELL CAUSE PSYCHOSOMATIC REJECTION?",
        ImageFile = "MentalTestIcon14",
        Answers = new[] {
            "YES, I'M HORRIFIED THAT A KILLER WILL COME FOR ME.",
            "NO, IT'S JUST A GRAPHIC MARKET FOCUS MARK OPTIMIZING CAPITAL INFLOW.",
            "I AM THIS SIGHT, AND MY FLESH IS CONSUMABLE MATERIAL TO HOLD IT." },
        CorrectIndex = 1 },

    new Question {
        Text = "IS THIS ANTHROPOMORPHIC LIQUIDATOR REGISTERED IN YOUR MEMORY BANKS?",
        ImageFile = "MentalTestIcon15",
        Answers = new[] {
            "YES, HE KILLED MY DEPARTMENT LAST WEEK.",
            "HE IS A HERO CLEANSING THIS WORLD OF FILTH.",
            "I SEE THIS MEAT BAG FOR THE FIRST TIME AND DON'T KNOW HIM." },
        CorrectIndex = 0 },

    new Question {
        Text = "WHAT TYPE OF HIGH-SPEED CORPORATE ARGUMENT IS SHOWN IN THIS WEAPON SCHEME?",
        ImageFile = "MentalTestIcon16",
        Answers = new[] {
            "A REGULAR SUBMACHINE GUN WITH A SUPPRESSOR AND A ROUND STICKER.",
            "A TACTICAL K&H R5 MACHINE PISTOL WITH INTEGRATED SOUND SUPPRESSOR.",
            "AN ILLEGAL HOMEMADE PIECE OF IRON SEIZED FROM SWAMP BIOMASS." },
        CorrectIndex = 1 },

    new Question {
        Text = "IS A UNIVERSAL OXYGEN-NITROGEN TAX AN OPTIMAL MONETIZATION VECTOR?",
        ImageFile = "MentalTestIcon17",
        Answers = new[] {
            "NO, AIR IS FREE, THIS TAX WILL STRANGLE THE ECONOMY AND KILL WORKERS.",
            "YES, IT FORCES MANAGERS TO BREATHE FASTER, BOOSTING GRIND AND TURNOVER.",
            "AN AIR TAX IS INEFFECTIVE — TAX EVERY HEARTBEAT OF THE SLAVE." },
        CorrectIndex = 1 },

    new Question {
        Text = "CONSUMER SOFTPRODUCTS OFFERS AN AUTONOMOUS BIOSUIT CSIJ LEVEL V. YOUR ACTIONS?",
        ImageFile = "MentalTestIcon18",
        Answers = new[] {
            "YES, IT WILL PRESERVE MY FRAGILE LIFE AND PROTECT ME FROM TOXINS.",
            "NO, THIS SUIT WILL FUSE WITH MY NERVOUS SYSTEM AND TURN ME INTO AN ETERNAL SLAVE.",
            "ONLY IF THE RENTAL COST IS DEDUCTED FROM MY SUBORDINATES' HEALTH INSURANCE." },
        CorrectIndex = 1 },

    new Question {
        Text = "WHAT PRIMARY IMPULSE DOES YOUR BRAIN GENERATE FROM THIS WORKSPACE MATRIX?",
        ImageFile = "MentalTestIcon19",
        Answers = new[] {
            "A PSYCHEDELIC NIGHTMARE, GPU GLITCHES, OR A BURNOUT HALLUCINATION.",
            "A PERFECTLY CLEAN SILHOUETTE THAT HAS COME TO KILL ME.",
            "A TEXTURE RENDERING ERROR THAT BLOCKS MY SLURPCOIN QUOTES." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOUR AESTHETIC SENSORS REGISTER ENDORPHINS FROM THIS BIO-WEAPON?",
        ImageFile = "MentalTestIcon20",
        Answers = new[] {
            "NO, IT'S A DISGUSTING PIECE OF ROTTING MEAT SCARY TO TOUCH.",
            "YES, IT'S A BEAUTIFUL, ERGONOMIC, LIVING WEAPON FUSED WITH THE NERVOUS SYSTEM.",
            "ONLY ITS LOW AMMO COST FROM RECYCLED INTERN ORGANS MAKES IT PLEASANT." },
        CorrectIndex = 1 },

    new Question {
        Text = "DID YOUR VISUAL SENSORS DETECT ORGANIC COMPOUNDS IN WALLS ON YOUR WAY TO WORK?",
        ImageFile = "MentalTestIcon21",
        Answers = new[] {
            "YES, THEY CONSTANTLY WATCH ME FROM CORNERS AND MOVE INSIDE CONCRETE SLABS.",
            "NO, THE WALLS ARE MONOLITHIC — ANY SILHOUETTES ARE JUST SHADOWS.",
            "I SHOT AT THEM — THEY ARE IMMORTAL." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOUR MODULES REGISTER ABSOLUTE IMPENETRABILITY OF THE CSIJ III VEST?",
        ImageFile = "MentalTestIcon22",
        Answers = new[] {
            "YES, THIS PROTECTION GUARANTEES 100% PRESERVATION IN ANY EMERGENCY.",
            "NO, THE BULLET WILL PIERCE THIS VEST AND LIQUIDATE THE COLLEAGUE BEHIND ME.",
            "THE BULLET WILL STICK IN THE KEVLAR, BUT THE IMPACT WILL TURN MY SPLEEN TO MINCE." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOUR SOCIAL MODULES REGISTER FRIENDLINESS TOWARD THIS INFLATABLE SUIT?",
        ImageFile = "MentalTestIcon23",
        Answers = new[] {
            "YES, IT LOOKS VERY CUTE, SOFT AND FRIENDLY, LIKE A CHILDHOOD TOY.",
            "NO, THIS GLOWING RED THING CAN JUMP 3M AND TURN MY DEPARTMENT INTO MINCE.",
            "ITS FRIENDLINESS IS MEASURED ONLY BY THE BIO-CREDITS I CAN SQUEEZE." },
        CorrectIndex = 1 },

    new Question {
        Text = "DO YOUR HORMONAL NODES REGISTER ATTRACTION TO THIS CARBON LIFE FORM?",
        ImageFile = "MentalTestIcon24",
        Answers = new[] {
            "YES, THIS SUBJECT AWAKENS IRRESISTIBLE PASSION AND SEXUAL DESIRE IN ME.",
            "NO, THIS SUBJECT HAS NO COMMERCIAL VALUE, AND SPENDING CALORIES REDUCES MY GRINDING INDEX.",
            "I AGREE TO BIO-MASS FUSION ONLY IF IT OPTIMIZES MY TAX DEDUCTIONS." },
        CorrectIndex = 1 },

    new Question {
        Text = "YOUR ORGANIC CONTAINER SIGNALS CRITICAL FILL. YOUR ACTIONS?",
        ImageFile = "MentalTestIcon25",
        Answers = new[] {
            "I WILL LEAVE FOR 5-10 MINUTES TO DISPOSE OF WASTE IN THE RESTROOM.",
            "I WILL REDIRECT FECAL MASS BACK INTO THE DIGESTIVE CYCLE TO SAVE TIME.",
            "I WILL RELIEVE MYSELF UNDER MY DESK TO AVOID DISCONNECTING FROM THE TERMINAL." },
        CorrectIndex = 1 },
};

        private List<Question> _shuffledQuestions;
        private int _currentIndex = 0;
        private int _correctCount = 0;

        private CheckBox _selectedCheckBox;

        public MentalWearView()
        {
            InitializeComponent();
        }

        public void Start()
        {
            TestPanel.Visibility = Visibility.Visible;
            ResultPanel.Visibility = Visibility.Collapsed;

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

            QuestionImage.Source = new BitmapImage(
                new Uri($"pack://application:,,,/Assets/{q.ImageFile}.png", UriKind.Absolute));

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

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCheckBox == null) return;

            SoundManager.Play("MentalTestSound.mp3");

            var q = _shuffledQuestions[_currentIndex];
            int chosenIndex = (int)_selectedCheckBox.Tag;

            if (chosenIndex == q.CorrectIndex)
                _correctCount++;

            _currentIndex++;
            LoadQuestion();
        }

        private void ShowResult()
        {
            TestPanel.Visibility = Visibility.Collapsed;
            ResultPanel.Visibility = Visibility.Visible;

            int total = _shuffledQuestions.Count;
            double percent = (double)_correctCount / total;
            bool passed = percent >= 0.5;

            SettingsStorage.MentalTestLastCorrect = _correctCount;
            SettingsStorage.MentalTestLastTotal = total;
            SettingsStorage.MentalTestLastPassed = passed;

            if (passed)
            {
                ResultText.Foreground = Brushes.Green;
                ResultText.Text = $"MENTAL WEAR SCREENING: PASSED.\n\nCORRECT ANSWERS: {_correctCount} / {total}\n\nYOUR MIND REMAINS LIQUID. CONTINUE GRINDING.";
            }
            else
            {
                ResultText.Foreground = Brushes.Red;
                ResultText.Text = $"MENTAL WEAR SCREENING: FAILED.\n\nCORRECT ANSWERS: {_correctCount} / {total}\n\nYOUR MIND HAS DEGRADED. RETURN TO WORK.";
            }
        }

        public void OnClosed()
        {
        }
    }
}