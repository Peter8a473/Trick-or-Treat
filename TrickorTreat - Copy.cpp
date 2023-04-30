#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define BIRD 0
#define BUNNY 1
#define CAT 2
#define DOG 3
#define FISH 4

#define PRINCESS 0
#define ROBOT 1
#define SPIDER 2
#define VAMPIRE 3

void welcomeScreen();
void clearScreen();

int compare[4][5];
int again = 1;
int arraydoor[4] = {PRINCESS, ROBOT, SPIDER, VAMPIRE};
int arrayOutfit[5] = {BIRD, BUNNY, CAT, DOG, FISH};
int score = 0;

int doorPrincess = 5;
int doorRobot = 5;
int doorSpider = 5;
int doorVampire = 5;

int main() {
    welcomeScreen();
    clearScreen();

    while (again == 1) {
        int door = 0;
        int outfit = 0;
        int random;
        char doorOutfit[10];
        char playerOutfit[10];
        int invalid = 0;

        if ((doorPrincess == 0) && (doorRobot == 0) && (doorSpider == 0) && (doorPrincess == 0)) {
            printf("Congradulations! Your score is %d!\n", score);
            system("pause");
            break;
        }

        //characterDoor
        srand(time(0));
        random = (rand() % 4) + 1;

        //makes sure that one person doesn't occur 5+ times
        if (((doorPrincess == 0) && (random == 1)) || ((doorRobot == 0) && (random == 2)) || ((doorSpider == 0) && (random == 3)) || ((doorVampire == 0) && (random == 4))) {
            continue;
        }

        switch (random) {
            case 1:
            door = PRINCESS;
            strcpy(doorOutfit, "princess");
            doorPrincess--;
            break;

            case 2:
            door = ROBOT;
            strcpy(doorOutfit, "robot");
            doorRobot--;
            break;

            case 3:
            door = SPIDER;
            strcpy(doorOutfit, "spider");
            doorSpider--;
            break;

            case 4:
            door = VAMPIRE;
            strcpy(doorOutfit, "vampire");
            doorVampire--;
            break;
        }
        printf("The %s is approaching the door.\n", doorOutfit);

        //characterOutfit
        while (invalid == 0) {
            printf("Choose an outfit (1-5)\n");
            int outfitTemp;
            scanf("%d", &outfitTemp);
            switch (outfitTemp) {
                case 1:
                outfit = BIRD;
                strcpy(playerOutfit, "Bird");
                invalid = 1;
                break;

                case 2:
                outfit = BUNNY;
                strcpy(playerOutfit, "Bunny");
                invalid = 1;
                break;

                case 3:
                outfit = CAT;
                strcpy(playerOutfit, "Cat");
                invalid = 1;
                break;

                case 4:
                outfit = DOG;
                strcpy(playerOutfit, "Dog");
                invalid = 1;
                break;

                case 5:
                outfit = FISH;
                strcpy(playerOutfit, "Fish");
                invalid = 1;
                break;

                default:
                printf("error. invalid input.\n\n");
                invalid = 0;
                break;
            }
        }
        printf("You chose a %s.\n", playerOutfit);

        // continue?
        if (compare[door][outfit] == 0) {
            compare[door][outfit] = 1;
            printf("Congrats!\n");
            system("pause");
            clearScreen();
            score++;
        }
        else if (compare[door][outfit] == 1) {
            again = 0;
            printf("Sorry!\n");
            printf("Your final score was %d\n", score);
            system("pause");
        }
    }
}

void welcomeScreen()
{
    // title
    printf("\t\tXXXXXX OOOOO  XXXXXX  OOOOO XX  XX\t             \tOOOOOO XXXXX  OOOOOO  XXXX  XXXXXX\n");
    printf("\t\t  XX   OO  OO   XX   OO     XX XX \t             \t  OO   XX  XX OO     XX  XX   XX  \n");
    printf("\t\t  XX   OOOOO    XX   OO     XXXX  \t OOOO  XXXXX \t  OO   XXXXX  OOOOOO XXXXXX   XX  \n");
    printf("\t\t  XX   OO OO    XX   OO     XX XX \tOO  OO XX  XX\t  OO   XX XX  OO     XX  XX   XX  \n");
    printf("\t\t  XX   OO  OO XXXXXX  OOOOO XX  XX\t OOOO  XX    \t  OO   XX  XX OOOOOO XX  XX   XX  \n");
    printf("\n\n");

    // game rules
    printf("TRICK or TREAT GAME RULES: \n");
    printf("\t1. You want to get as much candy from a house as possible. \n");
    printf("\t2. There are 4 different people in the house: \n");
    printf("\t\to One with a princess costume \n");
    printf("\t\to One with a robot costume \n");
    printf("\t\to One with a spider costume \n");
    printf("\t\to One with a vampire costue \n");
    printf("\t3. You have 5 different outfits (labeled 1-5). \n");
    printf("\t4. Only 1 person will answer the door at a time (chosen at random). \n");
    printf("\t5. Before they open the door, you will be able to switch your costume. \n");
    printf("\t6. A person will give you candy if you are wearing a costume they haven't seen you wear already. \n");
    printf("\t7. Each piece of candy is worth a point. \n");
    printf("\t8. If a person answers the door and you are wearing a costume they've already seen you as, it is game over. \n");
}

void clearScreen()
{
    printf("\t\t\tHit <Enter> to continue!\n");

    // store input of the "enter" key
    char enter;
    scanf("%c", &enter);
    system("cls");
}
