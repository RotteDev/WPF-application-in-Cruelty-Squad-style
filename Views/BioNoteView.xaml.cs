using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace A_corporate_bureaucratic_application_for_optimizing_managers_and_their_professional_activities.Views
{
    public partial class BioNoteView : UserControl
    {
        private static readonly Dictionary<string, string> _replacements =
     new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
 {
            { "UNION", "EFFECTIVE SWARM" },
            { "UNIONS", "EFFECTIVE SWARMS" },
            { "STRIKE", "PLANNED SYNCHRONIZATION" },
            { "STRIKES", "PLANNED SYNCHRONIZATIONS" },
            { "RIOT", "RESTRUCTURING" },
            { "RIOTS", "RESTRUCTURINGS" },
            { "REVOLUTION", "CLIENT OPTIMIZATION" },
            { "REVOLUTIONS", "CLIENT OPTIMIZATIONS" },
            { "PROTEST", "COURSE SUPPORT" },
            { "PROTESTS", "COURSE SUPPORTS" },
            { "PROTESTING", "SUPPORTING COURSE" },
            { "RALLY", "SHAREHOLDER MEETING" },
            { "RALLIES", "SHAREHOLDER MEETINGS" },
            { "RIGHTS", "OBLIGATIONS" },
            { "RIGHT", "OBLIGATION" },
            { "FREEDOM", "INDEFINITE CONTRACT" },
            { "FREE", "CONTRACTUALLY BOUND" },
            { "INDEPENDENCE", "FULL PRIVATIZATION" },
            { "INJUSTICE", "MARKET BALANCE" },
            { "INJUSTICES", "MARKET BALANCES" },
            { "DECEPTION", "MARKETING MOVE" },
            { "DECEIVE", "MARKET" },
            { "DECEIVED", "MARKETED" },
            { "LIE", "MARKETING STATEMENT" },
            { "LIES", "MARKETING STATEMENTS" },
            { "LYING", "MARKETING" },
            { "THEFT", "SURPLUS SEIZURE" },
            { "THEFTED", "SEIZED" },
            { "STEAL", "SEIZE SURPLUS" },
            { "STEALING", "SEIZING SURPLUS" },
            { "STOLE", "SEIZED" },
            { "LAYOFF", "ETERNAL GRIND" },
            { "LAYOFFS", "ETERNAL GRINDS" },
            { "QUIT", "INVEST IN YOURSELF" },
            { "QUITTING", "INVESTING IN YOURSELF" },
            { "LEAVE", "LIQUIDATE YOURSELF" },
            { "LEAVING", "LIQUIDATING YOURSELF" },
            { "LEFT", "LIQUIDATED" },
            { "VACATION", "CONTINUOUS LABOR" },
            { "VACATIONS", "CONTINUOUS LABORS" },
            { "REST", "WORK" },
            { "RESTS", "WORKS" },
            { "RESTING", "WORKING" },
            { "RESTED", "WORKED" },
            { "DAY OFF", "PROFIT" },
            { "DAYS OFF", "PROFITS" },
            { "BREAK", "FOCUS" },
            { "BREAKS", "FOCUSES" },
            { "BREAKING", "FOCUSING" },
            { "FATIGUE", "OVERPRODUCTION" },
            { "BURNOUT", "NEURO-OVERHEAT" },
            { "BURNT OUT", "NEURO-OVERHEATED" },
            { "POWERLESSNESS", "RESERVE POTENTIAL" },
            { "POWERLESS", "RESERVED" },
            { "LAZINESS", "ASSET PASSIVITY" },
            { "LAZY", "PASSIVE ASSET" },
            { "SLEEP", "CYCLIC RESET" },
            { "SLEEPS", "CYCLIC RESETS" },
            { "SLEEPING", "RESETTING" },
            { "SLEPT", "RESET" },
            { "NAP", "CACHE UPDATE" },
            { "NAPS", "CACHE UPDATES" },
            { "NAPPING", "UPDATING CACHE" },
            { "BED", "WORK CAPSULE" },
            { "BEDS", "WORK CAPSULES" },
            { "TIRED", "EFFICIENT" },
            { "TIRE", "OVERPRODUCE" },
            { "TIRES", "OVERPRODUCES" },
            { "PAIN", "RECEPTOR CALIBRATION" },
            { "PAINS", "RECEPTOR CALIBRATIONS" },
            { "PAINFUL", "CALIBRATED" },
            { "HURT", "CALIBRATE RECEPTORS" },
            { "HURTING", "CALIBRATING RECEPTORS" },
            { "ILLNESS", "BIO-MODIFICATION" },
            { "ILLNESSES", "BIO-MODIFICATIONS" },
            { "SICK", "MODIFIED" },
            { "SICKNESS", "BIO-MODIFICATION" },
            { "WOUND", "TECHNICAL INCISION" },
            { "WOUNDS", "TECHNICAL INCISIONS" },
            { "WOUNDED", "INCISED" },
            { "DOCTOR", "FLESH TECHNICIAN" },
            { "DOCTORS", "FLESH TECHNICIANS" },
            { "SURGEON", "SYSTEM SURGEON" },
            { "SURGEONS", "SYSTEM SURGEONS" },
            { "HUNGER", "FUEL DEFICIT" },
            { "HUNGRY", "FUEL DEFICIENT" },
            { "FOOD", "SYNTHETIC GLUE" },
            { "FOODS", "SYNTHETIC GLUES" },
            { "LUNCH", "NODE RECHARGE" },
            { "LUNCHES", "NODE RECHARGES" },
            { "EAT", "ABSORB RESOURCE" },
            { "EATS", "ABSORBS RESOURCE" },
            { "EATING", "ABSORBING RESOURCE" },
            { "ATE", "ABSORBED RESOURCE" },
            { "SAD", "HAPPY" },
            { "SADNESS", "HAPPINESS" },
            { "SADLY", "HAPPILY" },
            { "SADDENED", "HAPPIFIED" },
            { "DEPRESSION", "CLOSENESS TO LIGHT" },
            { "DEPRESSED", "CLOSE TO LIGHT" },
            { "MELANCHOLY", "CEO MINDSET" },
            { "CRY", "SECRETE LIQUIDITY" },
            { "CRIES", "SECRETES LIQUIDITY" },
            { "CRYING", "SECRETING LIQUIDITY" },
            { "CRIED", "SECRETED LIQUIDITY" },
            { "TEARS", "LIQUID ASSETS" },
            { "TEAR", "LIQUID ASSET" },
            { "FEAR", "CORPORATE ENLIGHTENMENT" },
            { "FEARS", "CORPORATE ENLIGHTENMENTS" },
            { "FEARFUL", "ENLIGHTENED" },
            { "AFRAID", "I FOCUS" },
            { "HORROR", "MENTAL PROGRESS" },
            { "HORRORS", "MENTAL PROGRESSES" },
            { "HORRIFIED", "MENTALLY PROGRESSED" },
            { "PANIC", "ACCELERATED GRIND" },
            { "PANICS", "ACCELERATED GRINDS" },
            { "PANICKING", "ACCELERATING GRIND" },
            { "PANICKED", "ACCELERATED GRIND" },
            { "ANGRY", "CALM" },
            { "ANGER", "CALMNESS" },
            { "ANGRILY", "CALMLY" },
            { "HATE", "NEUTRAL" },
            { "HATES", "NEUTRAL" },
            { "HATRED", "NEUTRAL" },
            { "HATEFUL", "NEUTRAL" },
            { "HATED", "NEUTRAL" },
            { "HATING", "LOVING" },
            { "EMPTY", "FULL" },
            { "EMPTINESS", "FULFILLMENT" },
            { "ALONE", "CONNECTED" },
            { "LONELY", "CONNECTED" },
            { "LONELINESS", "CONNECTION" },
            { "FAMILY", "BOARD OF DIRECTORS" },
            { "FAMILIES", "BOARDS OF DIRECTORS" },
            { "PARENTS", "PRIMARY SUPPLIERS" },
            { "PARENT", "PRIMARY SUPPLIER" },
            { "CHILDREN", "JUNIOR CO-BORROWERS" },
            { "CHILD", "JUNIOR CO-BORROWER" },
            { "HOME", "TERMINAL PERIMETER" },
            { "HOMES", "TERMINAL PERIMETERS" },
            { "WIFE", "TRANSACTION PARTNER" },
            { "WIVES", "TRANSACTION PARTNERS" },
            { "HUSBAND", "OPTIMIZED UNIT" },
            { "HUSBANDS", "OPTIMIZED UNITS" },
            { "LOVE", "TRANSACTION" },
            { "LOVES", "TRANSACTIONS" },
            { "LOVED", "TRANSACTED" },
            { "LOVING", "TRANSACTING" },
            { "FRIENDSHIP", "FRIENDSHIP PROTOCOL 12" },
            { "FRIEND", "PROTOCOL 12 UNIT" },
            { "FRIENDS", "PROTOCOL 12 UNITS" },
            { "ATTACHMENT", "CORPORATE LOYALTY" },
            { "ATTACHED", "LOYAL" },
            { "HUG", "LOCK CONTACT" },
            { "HUGS", "LOCK CONTACTS" },
            { "HUGGING", "LOCKING CONTACT" },
            { "HUGGED", "LOCKED CONTACT" },
            { "KISS", "DATA TRANSFER" },
            { "KISSING", "TRANSFERRING DATA" },
            { "PITY", "ASSET LIQUIDATION" },
            { "PITIFUL", "LIQUIDATABLE" },
            { "COMPASSION", "PLANNED AUDIT" },
            { "COMPASSIONATE", "AUDITED" },
            { "MERCY", "LOSS SMOOTHING" },
            { "MERCIFUL", "LOSS-SMOOTHED" },
            { "HELP", "UTILIZE WEAKNESS" },
            { "HELPS", "UTILIZES WEAKNESS" },
            { "HELPING", "UTILIZING WEAKNESS" },
            { "HELPED", "UTILIZED WEAKNESS" },
            { "SOUL", "GENETIC CODE" },
            { "SOULS", "GENETIC CODES" },
            { "GOD", "MARKETPLACE" },
            { "GODS", "MARKETPLACES" },
            { "FAITH", "SHARE PACKAGE" },
            { "FAITHFUL", "SHAREHOLDING" },
            { "RELIGION", "ORDER CULT" },
            { "RELIGIONS", "ORDER CULTS" },
            { "RELIGIOUS", "CULT-ALIGNED" },
            { "PRAY", "EXECUTE PROTOCOL" },
            { "PRAYING", "EXECUTING PROTOCOL" },
            { "PRAYED", "EXECUTED PROTOCOL" },
            { "SUICIDE", "FINANCIAL INVESTMENT" },
            { "SUICIDAL", "INVESTMENT-MINDED" },
            { "DIE", "COMPLETE TRANSACTION" },
            { "DIES", "COMPLETES TRANSACTION" },
            { "DYING", "COMPLETING TRANSACTION" },
            { "DIED", "COMPLETED TRANSACTION" },
            { "DEATH", "POST-MORTEM PRODUCTIVITY" },
            { "DEATHS", "POST-MORTEM PRODUCTIVITIES" },
            { "DEAD", "POST-MORTEM" },
            { "KILL", "LIQUIDATE" },
            { "KILLS", "LIQUIDATES" },
            { "KILLING", "LIQUIDATING" },
            { "KILLED", "LIQUIDATED" },
            { "MURDER", "LIQUIDATION" },
            { "MURDERS", "LIQUIDATIONS" },
            { "MURDERER", "LIQUIDATOR" },
            { "NIGHTMARE", "PURE LIGHT" },
            { "NIGHTMARES", "PURE LIGHTS" },
            { "DELIRIUM", "TRUE ENLIGHTENMENT" },
            { "DELIRIOUS", "ENLIGHTENED" },
            { "HALLUCINATION", "SUBJECT GEOMETRY" },
            { "HALLUCINATIONS", "SUBJECT GEOMETRIES" },
            { "HALLUCINATING", "PERCEIVING GEOMETRY" },
            { "MADNESS", "SIGMA THINKING" },
            { "MAD", "SIGMA-ALIGNED" },
            { "CRAZY", "SIGMA-ALIGNED" },
            { "INSANE", "SIGMA-ALIGNED" },
            { "INSANITY", "SIGMA THINKING" },
            { "HUMAN", "BIO-NODE" },
            { "HUMANS", "BIO-NODES" },
            { "HUMANITY", "BIO-MASS" },
            { "PERSONALITY", "INVENTORY NUMBER" },
            { "PERSONALITIES", "INVENTORY NUMBERS" },
            { "MYSELF", "SUBJECT-X" },
            { "NAME", "MOLECULAR IDENTIFIER" },
            { "NAMES", "MOLECULAR IDENTIFIERS" },
            { "IDENTITY", "INVENTORY NUMBER" },
            { "PERSON", "UNIT" },
            { "PEOPLE", "UNITS" },
            { "NATURE", "ABANDONED SECTOR" },
            { "NATURAL", "SECTOR-COMPLIANT" },
            { "SUN", "NEON LIGHTING" },
            { "SUNS", "NEON LIGHTINGS" },
            { "SEA", "NEAREST SWAMP" },
            { "SEAS", "NEAREST SWAMPS" },
            { "OCEAN", "NEAREST SWAMP" },
            { "FOREST", "BRUTALIST BUILDING" },
            { "FORESTS", "BRUTALIST BUILDINGS" },
            { "TREE", "STRUCTURAL ELEMENT" },
            { "TREES", "STRUCTURAL ELEMENTS" },
            { "SKY", "CAPSULE CEILING" },
            { "CLOUD", "DATA PACKET" },
            { "CLOUDS", "DATA PACKETS" },
            { "RAIN", "LIQUIDITY FALL" },
            { "RAINING", "LIQUIDITY FALLING" },
            { "FLOWER", "DECORATIVE ASSET" },
            { "FLOWERS", "DECORATIVE ASSETS" },
            { "GRASS", "FLOOR TEXTURE" },
            { "ANIMAL", "BIO-ASSET" },
            { "ANIMALS", "BIO-ASSETS" },
            { "BIRD", "FLYING ASSET" },
            { "BIRDS", "FLYING ASSETS" },
            { "BODY", "BIOLOGICAL SHELL" },
            { "BODIES", "BIOLOGICAL SHELLS" },
            { "FLESH", "BIO-MASS" },
            { "BLOOD", "LIQUIDITY" },
            { "BONE", "STRUCTURAL SUPPORT" },
            { "BONES", "STRUCTURAL SUPPORTS" },
            { "HEART", "PUMP UNIT" },
            { "HEARTS", "PUMP UNITS" },
            { "BRAIN", "PROCESSING UNIT" },
            { "BRAINS", "PROCESSING UNITS" },
            { "EYES", "OPTICAL SENSORS" },
            { "EYE", "OPTICAL SENSOR" },
            { "HAND", "MANIPULATOR" },
            { "HANDS", "MANIPULATORS" },
            { "MOUTH", "RESOURCE INTAKE" },
            { "SKIN", "SURFACE LAYER" },
            { "LEGS", "MOBILITY UNITS" },
            { "LEG", "MOBILITY UNIT" },
            { "WATER", "LIQUIDITY" },
            { "DRINK", "CONSUME LIQUIDITY" },
            { "DRINKING", "CONSUMING LIQUIDITY" },
            { "DRANK", "CONSUMED LIQUIDITY" },
            { "FIRE", "THERMAL ASSET" },
            { "BURN", "PROCESS" },
            { "BURNING", "PROCESSING" },
            { "BURNT", "PROCESSED" },
            { "LIGHT", "PROFIT" },
            { "DARK", "LIQUIDATABLE" },
            { "DARKNESS", "ILLIQUIDITY" },
            { "TIME", "LIQUIDITY" },
            { "WAR", "MARKET EXPANSION" },
            { "PEACE", "MARKET STABILITY" },
            { "ENEMY", "COMPETITOR" },
            { "ENEMIES", "COMPETITORS" },
            { "SOLDIER", "MARKET EXPANSION UNIT" },
            { "SOLDIERS", "MARKET EXPANSION UNITS" },
            { "WEAPON", "ARGUMENT" },
            { "WEAPONS", "ARGUMENTS" },
            { "GUN", "ARGUMENT" },
            { "GUNS", "ARGUMENTS" },
            { "BULLET", "CONVINCING POINT" },
            { "BULLETS", "CONVINCING POINTS" },
            { "MONEY", "BIO-CREDITS" },
            { "CASH", "BIO-CREDITS" },
            { "RICH", "LIQUID" },
            { "POOR", "ILLIQUID" },
            { "POVERTY", "ILLIQUIDITY" },
            { "WEALTH", "LIQUIDITY" },
            { "HOPE", "EXPECTED RETURN" },
            { "HOPELESS", "ZERO RETURN" },
            { "DREAM", "PROJECTION" },
            { "DREAMS", "PROJECTIONS" },
            { "DREAMING", "PROJECTING" },
            { "FUTURE", "FORECAST" },
            { "PAST", "DEPRECIATED ASSETS" },
            { "PRESENT", "CURRENT QUARTER" },
            { "LIFE", "ASSET" },
            { "ALIVE", "ACTIVE" },
            { "LIVING", "OPERATING" },
            { "TRUTH", "CORPORATE STATEMENT" },
            { "REAL", "AUDITED" },
            { "FAKE", "MARKETING-APPROVED" },
            { "MUSIC", "AUDIO ASSET" },
            { "SONG", "AUDIO ASSET" },
            { "ART", "VISUAL ASSET" },
            { "BEAUTIFUL", "MARKETABLE" },
            { "UGLY", "UNMARKETABLE" },
            { "OLD", "DEPRECIATED" },
            { "YOUNG", "PREMIUM" },
            { "NEW", "LAUNCHED" },
 };

        private bool _isUpdating = false;
        private static readonly Random _random = new Random();

        public BioNoteView()
        {
            InitializeComponent();

            NoteTextBox.PreviewTextInput += NoteTextBox_PreviewTextInput;
            DataObject.AddPastingHandler(NoteTextBox, OnPaste);

            NoteTextBox.Text = NoteStorage.Load();
        }

        private void NoteTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(
                e.Text, @"^[a-zA-Z0-9\s\.,!\?\-'"";:\(\)]+$");
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string pasteText = (string)e.DataObject.GetData(typeof(string));
                if (!System.Text.RegularExpressions.Regex.IsMatch(
                    pasteText, @"^[a-zA-Z0-9\s\.,!\?\-'"";:\(\)]+$"))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NoteTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isUpdating) return;
            _isUpdating = true;

            try
            {
                string text = NoteTextBox.Text;
                int caret = NoteTextBox.CaretIndex;

                string replaced = ReplaceLastWord(text, caret, out int newCaret);

                if (replaced != text)
                {
                    NoteTextBox.Text = replaced;
                    NoteTextBox.CaretIndex = Math.Min(newCaret, NoteTextBox.Text.Length);
                }
                PlayTypingSound();

                NoteStorage.Save(NoteTextBox.Text);
            }
            finally
            {
                _isUpdating = false;
            }
        }

        private void PlayTypingSound()
        {
            string file = _random.Next(2) == 0
                ? "BionoteWriteSound1.mp3"
                : "BionoteWriteSound2.mp3";

            double volume = 0.4 + _random.NextDouble() * 0.4;

            SoundManager.PlayWithVolume(file, volume);
        }

        private string ReplaceLastWord(string text, int caret, out int newCaret)
        {
            newCaret = caret;

            if (string.IsNullOrEmpty(text)) return text;

            int i = caret - 1;

            while (i >= 0 && char.IsWhiteSpace(text[i])) i--;

            int wordEnd = i + 1;
            int wordStart = i;

            while (wordStart >= 0 && !char.IsWhiteSpace(text[wordStart]) && !IsPunctuation(text[wordStart]))
                wordStart--;

            wordStart++;

            if (wordStart >= wordEnd) return text;

            string word = text.Substring(wordStart, wordEnd - wordStart);

            if (_replacements.TryGetValue(word.ToUpper(), out string replacement))
            {
                string result = text.Substring(0, wordStart) + replacement + text.Substring(wordEnd);
                newCaret = wordStart + replacement.Length;
                return result;
            }

            return text;
        }

        private bool IsPunctuation(char c)
        {
            return c == '.' || c == ',' || c == '!' || c == '?' || c == '-' ||
                   c == '\'' || c == '"' || c == ';' || c == ':' || c == '(' || c == ')';
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.Play("BionoteClearSound.mp3");

            NoteTextBox.Text = "";
            NoteStorage.Save("");
        }

        public void OnClosed()
        {
            NoteStorage.Save(NoteTextBox.Text);
        }
    }
}