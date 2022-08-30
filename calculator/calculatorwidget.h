#ifndef CALCULATORWIDGET_H
#define CALCULATORWIDGET_H

#include <QWidget>

namespace Ui {
class CalculatorWidget;
}

class CalculatorWidget : public QWidget
{
    Q_OBJECT

public:
    explicit CalculatorWidget(QWidget *parent = 0);
    ~CalculatorWidget();

public slots:

    void clicked_one();
    void clicked_two();
    void clicked_three();
    void clicked_four();
    void clicked_five();
    void clicked_six();
    void clicked_seven();
    void clicked_eight();
    void clicked_nine();
    void clicked_add();
    void clicked_subtract();
    void clicked_multi();
    void clicked_divide();
    void clicked_left();
    void clicked_right();
    void clicked_delete();
    void clicked_clear();
    void clicked_equal();

private:
    QVariant evalExpression(const QString &str, int &pos) const;
    QVariant evalTerm(const QString &str, int &pos) const;
    QVariant evalFactor(const QString &str, int &pos) const;
    Ui::CalculatorWidget *ui;
};

#endif // CALCULATORWIDGET_H
