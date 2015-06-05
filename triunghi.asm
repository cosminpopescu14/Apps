 jmp code
w equ 100 ; dimensiuni latuturi triunghi, daca se modifica va fi nevoie de modificari la laturi
h equ 50
code: mov ah, 0
 mov al, 13h ; trecere in mod grafic 320x200
 int 10h
 
 ; afisare latura inferioare
 mov cx, 100+w
 mov dx, 20+h
 mov al, 36
u2: mov ah, 0ch
 int 10h
 dec cx
 cmp cx, 100
 ja u2   
 
 ; latura din stanga
 mov cx, 50+w
 mov dx, 20+h
 mov al, 47
u3: mov ah, 0ch
 int 10h
 dec dx
 cmp dx, 20
 ja u3
 
 ;latura oblica stanga
 mov cx, 100
 mov dx, 20+h    
 mov al, 39
 l3: mov ah, 0ch
  int 10h  
  inc cx
  dec dx
  cmp cx, 50
  cmp dx, 20
  ja l3 
  
  ;latura oblica dreapta
  mov cx, 200
  mov dx, 20+h
  mov al, 42
  l4: mov ah, 0ch
   int 10h
   dec cx
   dec dx
   cmp cx, 100
   cmp dx, 20
   ja l4 
   
 ; asteptare apasare tasta
 mov ah,00
 int 16h
