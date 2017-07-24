using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace YMK.Commons.Async
{
    public class TaskScheduler
    {
        /// <summary>
        /// Art der whentlichen Wiederholung, erste, zweit, dritte, vierte oder letzte Woche
        /// </summary>
        public enum DayOccurrence
        {
            First = 0,
            Second = 1,
            Third = 2,
            Fourth = 3,
            Last = 4
        }

        /// <summary>
        /// Monate im Jahr
        /// </summary>
        public enum MonthOfTheYeay
        {
            January = 0,
            February = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11
        }

        /// <summary>
        /// Einmalige Ausf・rung: Stellt das Ausf・rungsdatum dar
        /// </summary>
        public class TriggerSettingsOneTimeOnly
        {
            private DateTime _date;
            private bool _active;

            [XmlIgnore]
            public DateTime Date
            {
                get
                {
                    return _date;
                }
                set
                {
                    _date = value;
                }
            }

            [XmlElement("Date")]
            public string XMLDate
            {
                get { return this._date.ToString("yyyy-MM-dd HH:mm:ss"); }
                set { this.Date = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", null).Date; }
            }

            public bool Active
            {
                get
                {
                    return _active;
                }
                set
                {
                    _active = value;
                }
            }
        }

        /// <summary>
        /// T臠liche Ausf・rung: Legt den Interval der Ausf・rung fest
        /// </summary>
        public class TriggerSettingsDaily
        {
            private ushort _Interval;

            public ushort Interval
            {
                get
                {
                    return _Interval;
                }
                set
                {
                    _Interval = value;
                    if (_Interval < 0) _Interval = 0;
                }
            }
        }

        /// <summary>
        /// Whentliche Ausf・rung: Tage an denen der Task ausgef・rt werden soll
        /// </summary>
        public class TriggerSettingsWeekly
        {
            private bool[] _DaysOfWeek;
            /// <summary>
            /// Whentliche Ausf・rung: Aktiviert oder deaktiviert einen Wochentag
            /// </summary>
            public bool[] DaysOfWeek
            {
                get
                {
                    return _DaysOfWeek;
                }
                set
                {
                    _DaysOfWeek = value;
                }
            }

            public TriggerSettingsWeekly()
            {
                _DaysOfWeek = new bool[7];
            }
        }

        /// <summary>
        /// Einstellungen f・ Monatliches Ausf・ren eines Triggers - Details f・ DayOfWeek
        /// </summary>
        public class TriggerSettingsMonthlyWeekDay
        {
            private bool[] _WeekNumber;
            private bool[] _DayOfWeek;

            /// <summary>
            /// Monatliche Ausf・rung: n'tes Vorkommen eines Wochentages
            /// </summary>
            public bool[] WeekNumber
            {
                get
                {
                    return _WeekNumber;
                }
                set
                {
                    _WeekNumber = value;
                }
            }
            /// <summary>
            /// Monatliche Ausf・rung: Wochentage
            /// </summary>
            public bool[] DayOfWeek
            {
                get
                {
                    return _DayOfWeek;
                }
                set
                {
                    _DayOfWeek = value;
                }
            }

            public TriggerSettingsMonthlyWeekDay()
            {
                _WeekNumber = new bool[5];
                _DayOfWeek = new bool[7];
            }
        }

        /// <summary>
        /// Einstellungen f・ Monatliches Ausf・ren eines Triggers
        /// </summary>
        public class TriggerSettingsMonthly
        {
            private bool[] _Month;

            private bool[] _DaysOfMonth;
            private TriggerSettingsMonthlyWeekDay _WeekDay;

            /// <summary>
            /// Monatliche Ausf・rung: Stellt die aktivierten Monate dar
            /// </summary>
            public bool[] Month
            {
                get
                {
                    return _Month;
                }
                set
                {
                    _Month = value;
                }
            }
            /// <summary>
            /// Monatliche Ausf・rung: Stellt die Tage vom Monat dar, an denen der Task ausgef・rt werden soll
            /// </summary>
            public bool[] DaysOfMonth
            {
                get
                {
                    return _DaysOfMonth;
                }
                set
                {
                    _DaysOfMonth = value;
                }
            }
            /// <summary>
            /// Monatliche Ausf・rung: Wochentage
            /// </summary>
            public TriggerSettingsMonthlyWeekDay WeekDay
            {
                get
                {
                    return _WeekDay;
                }
                set
                {
                    _WeekDay = value;
                }
            }

            public TriggerSettingsMonthly()
            {
                _Month = new bool[12];
                _DaysOfMonth = new bool[32];
                _WeekDay = new TriggerSettingsMonthlyWeekDay();
            }

        }

        /// <summary>
        /// Einstellungen wann ein Trigger ausgelt werden soll
        /// </summary>
        public class TriggerSettings
        {
            private TriggerSettingsOneTimeOnly _OneTimeOnly;
            private TriggerSettingsDaily _Daily;
            private TriggerSettingsWeekly _Weekly;
            private TriggerSettingsMonthly _Monthly;

            public TriggerSettingsOneTimeOnly OneTimeOnly
            {
                get
                {
                    return _OneTimeOnly;
                }
                set
                {
                    _OneTimeOnly = value;
                }
            }
            public TriggerSettingsDaily Daily
            {
                get
                {
                    return _Daily;
                }
                set
                {
                    _Daily = value;
                }
            }
            public TriggerSettingsWeekly Weekly
            {
                get
                {
                    return _Weekly;
                }
                set
                {
                    _Weekly = value;
                }
            }
            public TriggerSettingsMonthly Monthly
            {
                get
                {
                    return _Monthly;
                }
                set
                {
                    _Monthly = value;
                }
            }

            public TriggerSettings()
            {
                _OneTimeOnly = new TriggerSettingsOneTimeOnly();
                _Daily = new TriggerSettingsDaily();
                _Weekly = new TriggerSettingsWeekly();
                _Monthly = new TriggerSettingsMonthly();
            }
        }

        /// <summary>
        /// OnTriggerEventArgs
        /// </summary>
        public class OnTriggerEventArgs : EventArgs
        {
            public OnTriggerEventArgs(TriggerItem item, DateTime triggerDate)
            {
                _item = item;
                _triggerDate = triggerDate;
            }
            private TriggerItem _item;
            private DateTime _triggerDate;
            public TriggerItem Item
            {
                get { return _item; }
            }
            public DateTime TriggerDate
            {
                get { return _triggerDate; }
            }
        }

        /// <summary>
        /// Stellt einen Eintrag in der Task-Liste dar
        /// </summary>
        public class TriggerItem
        {
            private DateTime _StartDate = DateTime.MinValue; // Wenn nicht anders angegeben den gesamten Zeitbereich verwenden
            private DateTime _EndDate = DateTime.MaxValue;
            private TriggerSettings _TriggerSettings; // Trigger-Flags - speichert die Einstellungen wann soll der Trigger ausgelt werden soll
            private DateTime _TriggerTime; // Aktuelle Trigger-Ausf・rung
            private const byte LastDayOfMonthID = 31; // 0..30 = Tage im Monat, 31=Letzter Tag im Monat
            private object _Tag; // Speichert ein Hilfsobjekt
            private bool _Enabled; // Trigger aktiviert
            public delegate void OnTriggerEventHandler(object sender, OnTriggerEventArgs e);
            public event OnTriggerEventHandler OnTrigger;
            public DateTime _appStartDate = DateTime.MinValue;//アプリ起動日時（TriggerItemを生成する時設定する）//add by I.TYOU 20150529

            /// <summary>
            /// Erstellt eine Instanz von TriggerItem
            /// </summary>
            public TriggerItem()
            {
                _TriggerSettings = new TriggerSettings();
            }

            /// <summary>
            /// Serialisiert das Object in einen XML-String
            /// </summary>
            /// <returns></returns>
            public String ToXML() // Konfiguration im XML-Format als String ausgeben
            {
                Boolean curStat = this.Enabled;
                this.Enabled = false; // Item beendet sein, sonst schl臠t der export fehl!
                XmlSerializer ser = new XmlSerializer(typeof(TriggerItem));
                TextWriter writer = new StringWriter();
                ser.Serialize(writer, this);
                writer.Close();
                this.Enabled = curStat;
                return writer.ToString();
            }

            /// <summary>
            /// Erzeugt ein TriggerItem aus einem XML-String
            /// </summary>
            /// <param name="Configuration"></param>
            /// <returns></returns>
            public static TriggerItem FromXML(string Configuration)
            {
                XmlSerializer ser = new XmlSerializer(typeof(TriggerItem));
                TextReader reader = new StringReader(Configuration);
                TriggerItem result = (TriggerItem)ser.Deserialize(reader);
                reader.Close();
                return result;
            }

            /// <summary>
            /// Speichert ein Hilfsobjekt 
            /// </summary>
            public object Tag
            {
                get
                {
                    return _Tag;
                }
                set
                {
                    _Tag = value;
                }
            }

            /// <summary>
            /// Aktiviert oder deaktiviert den Trigger
            /// </summary>
            public bool Enabled
            {
                get
                {
                    return _Enabled;
                }
                set
                {
                    _Enabled = value;
                    if (_Enabled)
                        _TriggerTime = FindNextTriggerDate(_StartDate);
                    else
                        _TriggerTime = new DateTime(1, 1, 1, _TriggerTime.Hour, _TriggerTime.Minute, _TriggerTime.Second); ;
                }
            }

            //add by I.TYOU 20140529 start
            /// <summary>
            /// アプリ起動日時（TriggerItemを生成する時設定する）
            /// </summary>
            [XmlIgnore]
            public DateTime AppStartDate
            {
                get
                {
                    return _appStartDate;
                }
                set
                {
                    _appStartDate = value;
                }
            }
            //add by I.TYOU 20140529 end

            /// <summary>
            /// Stellt das Anfangsdatum der Ausf・rung dar
            /// </summary>
            [XmlIgnore]
            public DateTime StartDate
            {
                get
                {
                    return _StartDate;
                }
                set
                {
                    _StartDate = value;
                    if (_EndDate < _StartDate) _EndDate = _StartDate;
                }
            }

            [XmlElement("StartDate")]
            public string XMLStartDate
            {
                get { return this._StartDate.ToString("yyyy-MM-dd HH:mm:ss"); }
                set { this.StartDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", null); }
            }


            /// <summary>
            /// Stellt das Enddatum der Ausf・rung dar
            /// </summary>
            [XmlIgnore]
            public DateTime EndDate
            {
                get
                {
                    return _EndDate;
                }
                set
                {
                    _EndDate = value.Date;
                }
            }

            [XmlElement("EndDate")]
            public string XMLEndDate
            {
                get { return this._EndDate.ToString("yyyy-MM-dd HH:mm:ss"); }
                set { this.EndDate = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", null); }
            }

            /// <summary>
            /// Stellt die Ausf・rungs - Uhrzeit dar
            /// </summary>
            [XmlIgnore]
            public DateTime TriggerTime
            {
                get
                {
                    return _TriggerTime;
                }
                set
                {
                    _TriggerTime = new DateTime(_TriggerTime.Year, _TriggerTime.Month, _TriggerTime.Day, value.Hour, value.Minute, value.Second);
                }
            }

            [XmlElement("TriggerTime")]
            public string XMLTriggerTime
            {
                get { return this.TriggerTime.ToString("HH:mm:ss"); }
                set { this.TriggerTime = DateTime.ParseExact(value, "HH:mm:ss", null); }
            }

            /// <summary>
            /// Ermittelt oder legt fest wann der Trigger ausgelt werden soll
            /// </summary>
            public TriggerSettings TriggerSettings
            {
                get
                {
                    return _TriggerSettings;
                }
                set
                {
                    _TriggerSettings = value;
                }
            }

            /// <summary>
            /// Ermittelt den Letzten Tag des angegebenen Monats
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private DateTime LastDayOfMonth(DateTime date)
            {
                return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            }

            /// <summary>
            /// Ermittel das wievielte Mal der Wochentag in diesem Monat an diesem Datum vorkommt
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private int WeekDayOccurInMonth(DateTime date)
            {
                byte count = 0;
                for (int day = 1; day <= date.Day; day++)
                    if (new DateTime(date.Year, date.Month, day).DayOfWeek == date.DayOfWeek)
                        count++;
                return count - 1;
            }

            /// <summary>
            /// Ermittelt ob dieser Tag das Letzte mal im Monat vorkommt
            /// </summary>
            /// <param name="date"></param>
            /// <returns></returns>
            private bool IsLastWeekDayInMonth(DateTime date)
            {
                return (WeekDayOccurInMonth(date.AddDays(7)) == 0); // Der Wochentag kommt als letztes vor wenn der gleiche Wochentag eine Woche sp舩er das Erste mal (im Monat) vorkommt
            }

            /// <summary>
            /// Trigger-Pr・ung f・ einmalige Ausf・rung
            /// </summary>
            /// <returns></returns>
            private bool TriggerOneTimeOnly(DateTime date)
            {
                return (_TriggerSettings.OneTimeOnly.Active && (_TriggerSettings.OneTimeOnly.Date == date));
            }

            /// <summary>
            /// Trigger-Pr・ung f・ t臠liche Ausf・rung
            /// </summary>
            /// <returns>True wenn an diesem Tag der Task ausgef・rt werden soll</returns>
            private bool TriggerDaily(DateTime date)
            {
                if ((date < _StartDate.Date) || (date > _EndDate.Date)) // Wenn das Relevante Datum ausserhalb des g・tigen Bereichs liegt => falscher Tag
                    return false;
                if (_TriggerSettings.Daily.Interval == 0) // 0: Trigger ist nicht aktiv
                    return false;
                DateTime RunTime = _StartDate.Date;
                while (RunTime.Date < date)
                    RunTime = RunTime.AddDays(_TriggerSettings.Daily.Interval);
                return (RunTime == date);
            }

            /// <summary>
            /// Trigger-Pr・ung f・ whentliche Ausf・rung
            /// </summary>
            /// <returns></returns>
            private bool TriggerWeekly(DateTime date)
            {
                if ((date < _StartDate.Date) || (date > _EndDate.Date)) // Wenn das Relevante Datum ausserhalb des g・tigen Bereichs liegt => falscher Tag
                    return false;
                return (_TriggerSettings.Weekly.DaysOfWeek[(int)date.DayOfWeek]);
            }

            /// <summary>
            /// Trigger-Pr・ung f・ monatliche Ausf・rung
            /// </summary>
            /// <returns></returns>
            private bool TriggerMonthly(DateTime date)
            {
                if ((date < _StartDate.Date) || (date > _EndDate.Date)) // Wenn das Relevante Datum ausserhalb des g・tigen Bereichs liegt => falscher Tag
                    return false;

                bool result = false;
                if (_TriggerSettings.Monthly.Month[date.Month - 1]) // In diesem Monat ausf・ren?
                {
                    if (_TriggerSettings.Monthly.DaysOfMonth[LastDayOfMonthID]) // Am letzten Tag im Monat ausf・ren?
                        result = (result || (date == LastDayOfMonth(date))); // ist es der letzte Tag im Monat?

                    result = (result || (_TriggerSettings.Monthly.DaysOfMonth[date.Day - 1])); // Tag ist aktiviert?

                    if (_TriggerSettings.Monthly.WeekDay.DayOfWeek[(int)date.DayOfWeek]) // Tag aktiviert?
                    {
                        if (_TriggerSettings.Monthly.WeekDay.WeekNumber[(int)DayOccurrence.Last]) // Letzes Vorkommen des Tages im Monat pr・en?
                            result = (result || (IsLastWeekDayInMonth(date)));

                        result = (result || _TriggerSettings.Monthly.WeekDay.WeekNumber[WeekDayOccurInMonth(date)]); // n'te Auftreten aktiviert?
                    }
                }
                return result;
            }

            /// <summary>
            /// Pr・t ob an einem bestimmten Datum der Trigger ausgelt w・de
            /// </summary>
            /// <returns></returns>
            public bool CheckDate(DateTime date)
            {
                return (TriggerOneTimeOnly(date) || TriggerDaily(date) || TriggerWeekly(date) || TriggerMonthly(date));
            }

            /// <summary>
            /// F・rt einen Triggerchek an einen bestimmten Zeitpunkt durch
            /// </summary>
            /// <param name="dateTime"></param>
            /// <returns></returns>
            public bool RunCheck(DateTime dateTimeToCheck)
            {
                if (_Enabled) // Trigger aktiv?
                {
                    if (dateTimeToCheck >= _TriggerTime) // Trigger-Zeit ・erschritten? => Trigger auslen
                    {
                        OnTriggerEventArgs eventArgs = new OnTriggerEventArgs(this, _TriggerTime);
                        
                        //update by I.TYOU 20140529 失効日付を無視するため       start
                        DateTime curTime = _TriggerTime;
                        _TriggerTime = FindNextTriggerDate(_TriggerTime.AddDays(1)); // Einen Tag sp舩er fortfahren
                        //if (OnTrigger != null)
                        //    OnTrigger(this, eventArgs);
                        if (curTime >= _appStartDate)
                        {
                           if (OnTrigger != null)
                                OnTrigger(this, eventArgs);
                        }
                        //update by I.TYOU 20140529 失効日付を無視するため       end
                        
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// Sucht den Zeitpunkt der n臘hsten Ausf・rung
            /// </summary>
            private DateTime FindNextTriggerDate(DateTime lastTriggerDate)
            {
                if (!_Enabled)
                    return DateTime.MaxValue;

                DateTime date = lastTriggerDate.Date;
                while (date <= _EndDate)
                {
                    if (CheckDate(date.Date))
                        return new DateTime(date.Year, date.Month, date.Day, _TriggerTime.Hour, _TriggerTime.Minute, _TriggerTime.Second);
                    date = date.AddDays(1);
                }
                return DateTime.MaxValue;
            }

            /// <summary>
            /// Ermittelt den Zeitpunkt der n臘hsten Ausf・rung
            /// </summary>
            /// <returns></returns>
            public DateTime GetNextTriggerTime()
            {
                if (_Enabled)
                    return _TriggerTime;
                else
                    return DateTime.MaxValue;
            }
        }

        /// <summary>
        /// Stellt eine Collection von TriggerItems dar
        /// </summary>
        public class TriggerItemCollection : CollectionBase
        {
            public TriggerItem this[int index]
            {
                get
                {
                    return ((TriggerItem)List[index]);
                }
                set
                {
                    List[index] = value;
                }
            }

            public int Add(TriggerItem value)
            {
                return (List.Add(value));
            }

            public int IndexOf(TriggerItem value)
            {
                return (List.IndexOf(value));
            }

            public void Insert(int index, TriggerItem value)
            {
                List.Insert(index, value);
            }

            public void Remove(TriggerItem value)
            {
                List.Remove(value);
            }

            public bool Contains(TriggerItem value)
            {
                return (List.Contains(value));
            }

            protected override void OnInsert(int index, Object value)
            {
            }

            protected override void OnRemove(int index, Object value)
            {
            }

            protected override void OnSet(int index, Object oldValue, Object newValue)
            {
            }

            protected override void OnValidate(Object value)
            {
                if (value.GetType() != typeof(TaskScheduler.TriggerItem))
                    throw new ArgumentException("Das angegebene Argument ist kein TaskScheduler-Element", "value");
            }

        }

        /// <summary>
        /// Collection von TriggerItems
        /// </summary>
        private TriggerItemCollection _triggerItems;

        /// <summary>
        /// Pause zwischen den einzelnen Trigger-Checks
        /// </summary>
        private int _Interval = 500; // Standard ist jede Halbe Sekunde einen TriggerCheck ausf・ren

        /// <summary>
        /// Scheduler aktiv?
        /// </summary>
        private bool _Enabled = false;

        /// <summary>
        /// Check-Timer f・ den Trigger
        /// </summary>
        private System.Windows.Forms.Timer _triggerTimer;

        /// <summary>
        /// Klassen-Konstruktor...
        /// </summary>
        public TaskScheduler()
        {
            _triggerItems = new TriggerItemCollection();
            _triggerTimer = new System.Windows.Forms.Timer();
            _triggerTimer.Tick += new EventHandler(_triggerTimer_Tick);
        }

        /// <summary>
        /// Ermittelt den Trigger-Pr・interval oder legt diesen fest
        /// </summary>
        public int Interval
        {
            get
            {
                return _Interval;
            }
            set
            {
                _Interval = value;
            }
        }

        /// <summary>
        /// Scheduler aktivieren/deaktivieren
        /// </summary>
        public bool Enabled
        {
            get
            {
                return _Enabled;
            }
            set
            {
                _Enabled = value;
                if (_Enabled) Start();
                else
                    Stop();
            }
        }

        /// <summary>
        /// F・t ein neues Trigger-Item hinzu
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public TriggerItem AddTrigger(TriggerItem item)
        {
            return _triggerItems[_triggerItems.Add(item)];
        }

        /// <summary>
        /// Aktiviert den Scheduler
        /// </summary>
        private void Start()
        {
            _triggerTimer.Interval = _Interval;
            _triggerTimer.Start();
        }

        /// <summary>
        /// Stoppt den Scheduler
        /// </summary>
        private void Stop()
        {
            _triggerTimer.Stop();
        }

        /// <summary>
        /// Stellt eine Liste mit TriggerItems dar
        /// </summary>
        public TriggerItemCollection TriggerItems
        {
            get
            {
                return _triggerItems;
            }
        }

        /// <summary>
        /// Ereignisbehandlung f・ den Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _triggerTimer_Tick(object sender, EventArgs e)
        {
            _triggerTimer.Stop();
            foreach (TriggerItem item in TriggerItems)
                if (item.Enabled)
                    while (item.TriggerTime <= DateTime.Now)
                        item.RunCheck(DateTime.Now);
            _triggerTimer.Start();
        }
    }
}

