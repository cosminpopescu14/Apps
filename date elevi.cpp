// 10.7.2013
//program care citeste o structura si scrie in fisier ceea ce citeste


#include <stdio.h>
#include <conio.h>
#include <stdlib.h>


typedef struct elev
{
	char nume[15];
	char prenume[15];
	float medie[10];
	
}elev;


//citesc datele elevului

void read_data (int nr_elevi, elev elv[50])
{
	FILE *fisier;
	fisier = fopen("C://output//date elevi.txt", "w+");
	if(fisier == NULL)
		{
			puts("eroare!!");
		}
	int i;
	for(i = 1; i <= nr_elevi; i++)
	{
		printf("nume elev:");
	    scanf("%s", elv[i].nume);
	    printf("prenume elev:");
	 	scanf("%s", elv[i].prenume);
		printf("medie elev");
		scanf("%f", elv[i].medie);
		printf("________________________\n");
	}
	for(i = 1; i <= nr_elevi; i++)
	fprintf(fisier, " %d %s, %s, %f \n", i, elv[i].nume, elv[i].prenume, elv[i].medie);
	fclose(fisier);
}














int main (void)
{   int nr_elevi;//nr de elevi
    elev elv[50]; 
    printf("aintroduceti nr de elevi:");
    scanf("%d", &nr_elevi);
	read_data(nr_elevi, elv);
	getch();
}
