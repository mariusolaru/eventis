# EventIS

## Idea & Description
Ne dorim sa construim o platforma bazata pe promovarea de evenimente culturale, sociale si activitati recreative la nivel local (Iasi), dar nu numai (posibilitatea de extindere spre alte orase). Obiectivul general al aplicatiei este acela de a identifica, a selecta si a promova evenimentele locale, creand un spatiu alternativ, care sa aduca beneficii pe termen lung tuturor utilizatorilor.

Fiecare utilizator poate accesa o gama larga de evenimente (impartite pe categorii, locatii, etc.), poate sa-si creeze propriul eveniment la care va participa (custom events) in conformitate cu programul, nevoile si cerintele sale. Utilizatorul isi poate gestiona evenimentele, locatiile preferate si propriile date, editandu-le dupa bunul plac.

## Details
https://docs.google.com/document/d/1M2mY-u96_EFCsxOXUPiKV_MGg3T75uZuO16Sx197L5M/edit?usp=sharing

## Architecture & Technology Stack
Vom folosi o arhitectura Onion pentru o shift-are a dependentelor precum UI sau solutia de storage folosita de datele propriu-zise si business logic-ul nostru.

In ceea ce priveste evenimentele, ne vom folosi de API-ul celor de la Facebook pentru gasirea de evenimente ce se vor incadra in setul nostru de filtre, iar partea de locatii ale evenimentelor vor fi luate cu ajutorul API-ului celor de la Google. Pe parcurs vom folosi si alte API-uri pentru a afla vremea intre orele respectivului eveniment, etc.

Pe partea de front-end ne vom folosi de Angular
