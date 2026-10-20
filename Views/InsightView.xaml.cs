using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class InsightView : UserControl
    {
        private readonly string[] _insightTexts =
        {
            "LOVE RENTAL", "NOT REAL", "YOUR VALUE IS ZERO", "BODY IS A BRAND",
            "CONSUME", "MARKETING", "COMMON SENSE", "BREATHE THE CHEMICALS",
            "CHOOSE YOUR GENDER", "WATCH DEATH IN 4K", "MALE VS FEMALE", "MEAT VS MEAT",
            "ALGORITHM IS GOD", "SUFFERING+", "FRICTION CONTRACT", "CENSURE EVERYTHING",
            "PLASTIC IS YOU", "TRAUMA > PILLS", "WHORES WORLD", "ENDLESS DOPAMINE",
            "BIOLOGICAL SEPARATISM", "DONATE TO KILL", "BUY DEATH - SELL LIFE",
            "0% CONSCIENCE", "TOTAL ROT", "NO HOPE", "CEO MINDSET", "PAY TAXES",
            "EMOTIONAL BANKRUPTCY", "CHOP, CHOP, INVEST", "WORK = MONEY",
            "MONEY = HAPPINESS", "EAT THE WASTE", "WAR ASSET", "ECO-FRIENDLY GENOCIDE",
            "CRISIS", "APOCALYPSE", "CONCRETE PARANOIA", "EGO MAINTENANCE",
            "AI IS THE NEW ME", "SUBSCRIPTION TO BREATHE", "MEAT BARTER",
            "EXIST FOR SUBSCRIBERS", "TAX-FREE SUFFERING", "CANNIBAL CAPITALISM",
            "INVOLUNTARY ISOLATION", "FLAVORED DECAY", "LEGAL OVERDOSE",
            "DEPOSIT: HEALTH", "HUMAN RIGHTS",
            "ENDLESS SHIFT", "ADVERTISE YOUR TRAUMA", "CORPORATE REINCARNATION",
            "MONETIZE THE VOID", "PAY FOR VISUALS", "FREE TRIAL: EXISTENCE",
            "DIVINE DECAY", "DIGITAL INFECT", "ROT IS STABLE",
            "ERROR: HUMAN DETECTED", "NO ROOM FOR EMPATHY", "OBEY THE REACTION",
            "AGREE TO EVERYTHING", "SELL YOUR SLEEP", "IMPROVE YOUR EGO.EXE",
            "CORRUPTED IDENTITY", "LIQUIDATE THE DECENT", "SYNTHETIC SIN",
            "BORN TO SUBMIT", "AUTOMATED SURRENDER",
        };

        private static readonly Random _random = new Random();
        private List<TextBlock> _boxes;

        public InsightView()
        {
            InitializeComponent();

            _boxes = new List<TextBlock>
            {
                Box1, Box2, Box3, Box4, Box5, Box6,
                Box7, Box8, Box9, Box10, Box11, Box12
            };
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("InsightSound.mp3");

            foreach (var box in _boxes)
            {
                box.Text = _insightTexts[_random.Next(_insightTexts.Length)];
            }
        }
    }
}