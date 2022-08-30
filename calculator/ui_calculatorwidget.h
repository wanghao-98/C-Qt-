/********************************************************************************
** Form generated from reading UI file 'calculatorwidget.ui'
**
** Created by: Qt User Interface Compiler version 5.9.0
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CALCULATORWIDGET_H
#define UI_CALCULATORWIDGET_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QTextEdit>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CalculatorWidget
{
public:
    QGridLayout *gridLayout;
    QPushButton *btn4;
    QPushButton *btn_add;
    QPushButton *btn_right;
    QPushButton *btn8;
    QPushButton *btn_equal;
    QPushButton *btn2;
    QPushButton *btn6;
    QPushButton *btn3;
    QPushButton *btn_subtract;
    QPushButton *btn_left;
    QPushButton *btn9;
    QPushButton *btn7;
    QPushButton *btn_divide;
    QPushButton *btn_multip;
    QTextEdit *textBrowser;
    QPushButton *btn1;
    QPushButton *btn5;
    QPushButton *btn_delete;
    QPushButton *btn_clear;

    void setupUi(QWidget *CalculatorWidget)
    {
        if (CalculatorWidget->objectName().isEmpty())
            CalculatorWidget->setObjectName(QStringLiteral("CalculatorWidget"));
        CalculatorWidget->resize(475, 391);
        gridLayout = new QGridLayout(CalculatorWidget);
        gridLayout->setSpacing(6);
        gridLayout->setContentsMargins(11, 11, 11, 11);
        gridLayout->setObjectName(QStringLiteral("gridLayout"));
        btn4 = new QPushButton(CalculatorWidget);
        btn4->setObjectName(QStringLiteral("btn4"));

        gridLayout->addWidget(btn4, 4, 0, 1, 1);

        btn_add = new QPushButton(CalculatorWidget);
        btn_add->setObjectName(QStringLiteral("btn_add"));

        gridLayout->addWidget(btn_add, 2, 0, 1, 1);

        btn_right = new QPushButton(CalculatorWidget);
        btn_right->setObjectName(QStringLiteral("btn_right"));

        gridLayout->addWidget(btn_right, 4, 3, 1, 1);

        btn8 = new QPushButton(CalculatorWidget);
        btn8->setObjectName(QStringLiteral("btn8"));

        gridLayout->addWidget(btn8, 5, 1, 1, 1);

        btn_equal = new QPushButton(CalculatorWidget);
        btn_equal->setObjectName(QStringLiteral("btn_equal"));
        QSizePolicy sizePolicy(QSizePolicy::Minimum, QSizePolicy::Fixed);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(btn_equal->sizePolicy().hasHeightForWidth());
        btn_equal->setSizePolicy(sizePolicy);

        gridLayout->addWidget(btn_equal, 5, 3, 1, 1);

        btn2 = new QPushButton(CalculatorWidget);
        btn2->setObjectName(QStringLiteral("btn2"));

        gridLayout->addWidget(btn2, 3, 1, 1, 1);

        btn6 = new QPushButton(CalculatorWidget);
        btn6->setObjectName(QStringLiteral("btn6"));

        gridLayout->addWidget(btn6, 4, 2, 1, 1);

        btn3 = new QPushButton(CalculatorWidget);
        btn3->setObjectName(QStringLiteral("btn3"));

        gridLayout->addWidget(btn3, 3, 2, 1, 1);

        btn_subtract = new QPushButton(CalculatorWidget);
        btn_subtract->setObjectName(QStringLiteral("btn_subtract"));

        gridLayout->addWidget(btn_subtract, 2, 1, 1, 1);

        btn_left = new QPushButton(CalculatorWidget);
        btn_left->setObjectName(QStringLiteral("btn_left"));

        gridLayout->addWidget(btn_left, 3, 3, 1, 1);

        btn9 = new QPushButton(CalculatorWidget);
        btn9->setObjectName(QStringLiteral("btn9"));

        gridLayout->addWidget(btn9, 5, 2, 1, 1);

        btn7 = new QPushButton(CalculatorWidget);
        btn7->setObjectName(QStringLiteral("btn7"));

        gridLayout->addWidget(btn7, 5, 0, 1, 1);

        btn_divide = new QPushButton(CalculatorWidget);
        btn_divide->setObjectName(QStringLiteral("btn_divide"));

        gridLayout->addWidget(btn_divide, 2, 3, 1, 1);

        btn_multip = new QPushButton(CalculatorWidget);
        btn_multip->setObjectName(QStringLiteral("btn_multip"));

        gridLayout->addWidget(btn_multip, 2, 2, 1, 1);

        textBrowser = new QTextEdit(CalculatorWidget);
        textBrowser->setObjectName(QStringLiteral("textBrowser"));
        textBrowser->setReadOnly(true);

        gridLayout->addWidget(textBrowser, 0, 0, 1, 4);

        btn1 = new QPushButton(CalculatorWidget);
        btn1->setObjectName(QStringLiteral("btn1"));

        gridLayout->addWidget(btn1, 3, 0, 1, 1);

        btn5 = new QPushButton(CalculatorWidget);
        btn5->setObjectName(QStringLiteral("btn5"));

        gridLayout->addWidget(btn5, 4, 1, 1, 1);

        btn_delete = new QPushButton(CalculatorWidget);
        btn_delete->setObjectName(QStringLiteral("btn_delete"));

        gridLayout->addWidget(btn_delete, 1, 3, 1, 1);

        btn_clear = new QPushButton(CalculatorWidget);
        btn_clear->setObjectName(QStringLiteral("btn_clear"));

        gridLayout->addWidget(btn_clear, 1, 2, 1, 1);


        retranslateUi(CalculatorWidget);

        QMetaObject::connectSlotsByName(CalculatorWidget);
    } // setupUi

    void retranslateUi(QWidget *CalculatorWidget)
    {
        CalculatorWidget->setWindowTitle(QApplication::translate("CalculatorWidget", "CalculatorWidget", Q_NULLPTR));
        btn4->setText(QApplication::translate("CalculatorWidget", "4", Q_NULLPTR));
        btn_add->setText(QApplication::translate("CalculatorWidget", "+", Q_NULLPTR));
        btn_right->setText(QApplication::translate("CalculatorWidget", ")", Q_NULLPTR));
        btn8->setText(QApplication::translate("CalculatorWidget", "8", Q_NULLPTR));
        btn_equal->setText(QApplication::translate("CalculatorWidget", "=", Q_NULLPTR));
        btn2->setText(QApplication::translate("CalculatorWidget", "2", Q_NULLPTR));
        btn6->setText(QApplication::translate("CalculatorWidget", "6", Q_NULLPTR));
        btn3->setText(QApplication::translate("CalculatorWidget", "3", Q_NULLPTR));
        btn_subtract->setText(QApplication::translate("CalculatorWidget", "-", Q_NULLPTR));
        btn_left->setText(QApplication::translate("CalculatorWidget", "(", Q_NULLPTR));
        btn9->setText(QApplication::translate("CalculatorWidget", "9", Q_NULLPTR));
        btn7->setText(QApplication::translate("CalculatorWidget", "7", Q_NULLPTR));
        btn_divide->setText(QApplication::translate("CalculatorWidget", "/", Q_NULLPTR));
        btn_multip->setText(QApplication::translate("CalculatorWidget", "*", Q_NULLPTR));
        btn1->setText(QApplication::translate("CalculatorWidget", "1", Q_NULLPTR));
        btn5->setText(QApplication::translate("CalculatorWidget", "5", Q_NULLPTR));
        btn_delete->setText(QApplication::translate("CalculatorWidget", "Delete", Q_NULLPTR));
        btn_clear->setText(QApplication::translate("CalculatorWidget", "Clear", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class CalculatorWidget: public Ui_CalculatorWidget {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CALCULATORWIDGET_H
