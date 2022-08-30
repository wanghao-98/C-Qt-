#include "calculatorwidget.h"
#include "ui_calculatorwidget.h"

CalculatorWidget::CalculatorWidget(QWidget *parent) :
    QWidget(parent),
    ui(new Ui::CalculatorWidget)
{
//    connect(ui->btn1,SIGNAL(released()),this,SLOT(clicked_one()));

    ui->setupUi(this);
        connect(ui->btn1,&QPushButton::released,this,&CalculatorWidget::clicked_one);
        connect(ui->btn2,&QPushButton::released,this,&CalculatorWidget::clicked_two);
        connect(ui->btn3,&QPushButton::released,this,&CalculatorWidget::clicked_three);
        connect(ui->btn4,&QPushButton::released,this,&CalculatorWidget::clicked_four);
        connect(ui->btn5,&QPushButton::released,this,&CalculatorWidget::clicked_five);
        connect(ui->btn6,&QPushButton::released,this,&CalculatorWidget::clicked_six);
        connect(ui->btn7,&QPushButton::released,this,&CalculatorWidget::clicked_seven);
        connect(ui->btn8,&QPushButton::released,this,&CalculatorWidget::clicked_eight);
        connect(ui->btn9,&QPushButton::released,this,&CalculatorWidget::clicked_nine);
        connect(ui->btn_add,&QPushButton::released,this,&CalculatorWidget::clicked_add);
        connect(ui->btn_subtract,&QPushButton::released,this,&CalculatorWidget::clicked_subtract);
        connect(ui->btn_multip,&QPushButton::released,this,&CalculatorWidget::clicked_multi);
        connect(ui->btn_divide,&QPushButton::released,this,&CalculatorWidget::clicked_divide);
        connect(ui->btn_left,&QPushButton::released,this,&CalculatorWidget::clicked_left);
        connect(ui->btn_right,&QPushButton::released,this,&CalculatorWidget::clicked_right);
        connect(ui->btn_delete,&QPushButton::released,this,&CalculatorWidget::clicked_delete);
        connect(ui->btn_clear,&QPushButton::released,this,&CalculatorWidget::clicked_clear);
        connect(ui->btn_equal,&QPushButton::released,this,&CalculatorWidget::clicked_equal);

}

CalculatorWidget::~CalculatorWidget()
{
    delete ui;
}

QVariant Invalid;

//解析表达式，由公式字符串计算结果，
QVariant CalculatorWidget::evalExpression(const QString &str, int &pos) const
{
    //先解析第一项
    QVariant result = evalTerm(str, pos);
    //当没达到字符串末尾时，依此计算前两项的值，并把计算的值赋给第一项，重复计算，直到计算完毕
    while (str[pos] != QChar::Null) {
        QChar op = str[pos];
        //如果第一项后面不是+或-，则把结果返回
        if (op != '+' && op != '-')
            return result;
        //如果后面为+或者-，则继续解析第二项
        ++pos;
        //pos向后移动，获取第二项
        QVariant term = evalTerm(str, pos);
        //判断前两项是不是double，如果是，把结果计算出来，作为第一项的值，然后继续计算第三项
        if (result.type() == QVariant::Double
                && term.type() == QVariant::Double) {
            if (op == '+') {
                result = result.toDouble() + term.toDouble();
            } else {
                result = result.toDouble() - term.toDouble();
            }
        }//如果不是double，结果无效
        else {
            result = Invalid;
        }
    }
    //最后返回结果
    return result;
}

void CalculatorWidget::clicked_one()
{
    ui->textBrowser->insertPlainText(ui->btn1->text());
}

void CalculatorWidget::clicked_two()
{
    ui->textBrowser->insertPlainText(ui->btn2->text());
}

void CalculatorWidget::clicked_three()
{
    ui->textBrowser->insertPlainText(ui->btn3->text());
}

void CalculatorWidget::clicked_four()
{
    ui->textBrowser->insertPlainText(ui->btn4->text());
}

void CalculatorWidget::clicked_five()
{
    ui->textBrowser->insertPlainText(ui->btn5->text());
}

void CalculatorWidget::clicked_six()
{
    ui->textBrowser->insertPlainText(ui->btn6->text());
}

void CalculatorWidget::clicked_seven()
{
    ui->textBrowser->insertPlainText(ui->btn7->text());
}

void CalculatorWidget::clicked_eight()
{
    ui->textBrowser->insertPlainText(ui->btn8->text());
}

void CalculatorWidget::clicked_nine()
{
    ui->textBrowser->insertPlainText(ui->btn9->text());
}

void CalculatorWidget::clicked_add()
{
    ui->textBrowser->insertPlainText(ui->btn_add->text());
}

void CalculatorWidget::clicked_subtract()
{
    ui->textBrowser->insertPlainText(ui->btn_subtract->text());
}

void CalculatorWidget::clicked_multi()
{
    ui->textBrowser->insertPlainText(ui->btn_multip->text());
}

void CalculatorWidget::clicked_divide()
{
    ui->textBrowser->insertPlainText(ui->btn_divide->text());
}

void CalculatorWidget::clicked_left()
{
    ui->textBrowser->insertPlainText(ui->btn_left->text());
}

void CalculatorWidget::clicked_right()
{
    ui->textBrowser->insertPlainText(ui->btn_right->text());
}

void CalculatorWidget::clicked_delete()
{
    QString str=ui->textBrowser->toPlainText();
    str=str.left(str.size()-1);
    ui->textBrowser->clear();
    ui->textBrowser->insertPlainText(str);
}

void CalculatorWidget::clicked_clear()
{
    ui->textBrowser->clear();
}

void CalculatorWidget::clicked_equal()
{
    int pos=0;
    QString str=ui->textBrowser->document()->toPlainText();
    QStringList list=str.split("\n");
    str=list.last();
    if(str=="")
        return ;
    str.append(QChar::Null);
    QVariant value=evalExpression(str,pos);
    ui->textBrowser->append("="+value.toString()+"\n");

}

//解析项，和解析表达式类似
QVariant CalculatorWidget::evalTerm(const QString &str, int &pos) const
{
    //先获取第一个因子
    QVariant result = evalFactor(str, pos);
    //循环更新，先计算第一个因子和第二个因子的值，更新第一个，继续计算
    while (str[pos] != QChar::Null) {
        QChar op = str[pos];
        if (op != '*' && op != '/')
            return result;
        ++pos;
        //解析第二个因子
        QVariant factor = evalFactor(str, pos);
        if (result.type() == QVariant::Double
                && factor.type() == QVariant::Double) {
            if (op == '*') {
                result = result.toDouble() * factor.toDouble();
            } else {
                //如果是除法，要判断除数不等于0
                if (factor.toDouble() == 0.0) {
                    result = Invalid;
                } else {
                    result = result.toDouble() / factor.toDouble();
                }
            }
        } else {
            result = Invalid;
        }
    }
    return result;
}

//解析因子，最复杂，有括号，正负问题，处理括号问题时，用到了递归。
QVariant CalculatorWidget::evalFactor(const QString &str, int &pos) const
{
    QVariant result;
    bool negative = false;
    //判断是否负号开头
    if (str[pos] == '-') {
        negative = true;
        ++pos;
    }

    //判断有没有左括号
    if (str[pos] == '(') {
        ++pos;
        //递归调用，括号里视为表达式
        result = evalExpression(str, pos);
        //直到右括号出现
        if (str[pos] != ')')
            result = Invalid;
        ++pos;
    } else {
        QString token;
        //当前位置是字母或数字，或者等于.存入token
        while (str[pos].isNumber() || str[pos] == '.') {
            token += str[pos];
            ++pos;
        }
         bool ok;
         result = token.toDouble(&ok);
         if (!ok)
            result = Invalid;
    }
    //如果以负号开头，对整个处理结果取负号
    if (negative) {
        if (result.type() == QVariant::Double) {
            result = -result.toDouble();
        } else {
            result = Invalid;
        }
    }
    return result;
}
