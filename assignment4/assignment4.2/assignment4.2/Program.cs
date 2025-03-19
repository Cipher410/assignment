using System;
using System.Threading;

// 定义闹钟类
class AlarmClock
{
    // 定义 Tick 事件
    public event EventHandler Tick;
    // 定义 Alarm 事件
    public event EventHandler Alarm;

    // 闹钟的当前时间
    public DateTime CurrentTime { get; private set; }
    // 闹钟的响铃时间
    public DateTime AlarmTime { get; set; }

    // 构造函数
    public AlarmClock()
    {
        CurrentTime = DateTime.Now;
    }

    // 启动闹钟
    public void Start()
    {
        Console.WriteLine("闹钟已启动！");
        while (true)
        {
            // 更新当前时间
            CurrentTime = DateTime.Now;
            Console.WriteLine($"当前时间: {CurrentTime:HH:mm:ss}");

            // 触发 Tick 事件
            OnTick();

            // 检查是否到达响铃时间
            if (CurrentTime >= AlarmTime)
            {
                // 触发 Alarm 事件
                OnAlarm();
                break; // 响铃后停止闹钟
            }

            // 模拟每秒嘀嗒一次
            Thread.Sleep(1000);
        }
    }

    // 触发 Tick 事件
    protected virtual void OnTick()
    {
        Tick?.Invoke(this, EventArgs.Empty);
    }

    // 触发 Alarm 事件
    protected virtual void OnAlarm()
    {
        Alarm?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 创建闹钟实例
        AlarmClock alarmClock = new AlarmClock();

        // 设置响铃时间（当前时间 + 10 秒）
        alarmClock.AlarmTime = DateTime.Now.AddSeconds(10);

        // 订阅 Tick 事件
        alarmClock.Tick += (sender, e) =>
        {
            Console.WriteLine("嘀嗒...");
        };

        // 订阅 Alarm 事件
        alarmClock.Alarm += (sender, e) =>
        {
            Console.WriteLine("叮铃铃！时间到了！");
        };

        // 启动闹钟
        alarmClock.Start();
    }
}