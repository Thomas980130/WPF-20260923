using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            int totalPrice = 0;
            bool hasItem = false;

            // 建立彈出視窗的內容字串
            StringBuilder receiptText = new StringBuilder();
            receiptText.AppendLine("🧾 【飲料訂購明細】");
            receiptText.AppendLine("------------------------------------");

            // 定義菜單品項與單價（對應 XAML 中的 TextBox）
            var itemList = new List<(string Name, int Price, TextBox InputBox)>
            {
                ("伯爵紅茶", 30, txtCount1),
                ("波霸奶茶", 60, txtCount2),
                ("四季春茶", 30, txtCount3),
                ("百香雙響炮", 40, txtCount4)
            };

            // 逐一檢查數量
            foreach (var item in itemList)
            {
                // 防呆：確認使用者輸入的是否為非負整數
                if (int.TryParse(item.InputBox.Text, out int qty))
                {
                    if (qty > 0)
                    {
                        int subtotal = item.Price * qty; // 小計
                        totalPrice += subtotal;          // 累加總金額
                        hasItem = true;

                        receiptText.AppendLine($"• {item.Name} × {qty} 杯 = ${subtotal}");
                    }
                    else if (qty < 0)
                    {
                        MessageBox.Show($"「{item.Name}」數量不能為負數！", "輸入錯誤", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show($"請在「{item.Name}」的數量欄位輸入有效數字！", "輸入錯誤", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            // 若沒有點任何飲料
            if (!hasItem)
            {
                MessageBox.Show("請至少購買 1 杯飲料再送出訂單！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // 加上結尾與最終價格
            receiptText.AppendLine("------------------------------------");
            receiptText.AppendLine($"💰 最終總金額：${totalPrice} 元");

            // 彈出視窗顯示結果
            MessageBox.Show(receiptText.ToString(), "訂單明細確認", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}