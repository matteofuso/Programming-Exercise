1. What are the two parts of a class?
Dati membro e funzioni membro

2. What is the difference between the interface and the implementation in a class?
L'interfaccia è la "vetrina" che dice all'utente cosa può fare la classe e come usarla, mentre l'implementazione è il codice vero e proprio che mostra come fa le cose.

3. Why is a constructor used for the Date type instead of an init_day() function?
Perché con una normale funzione come init_day() l'utente può dimenticarsi di chiamarla o modificare i dati a mano creando uno stato non valido. Il costruttore invece rende obbligatorio inizializzare l'oggetto nel momento esatto in cui viene creato, evitando che venga usato per errore senza valori validi.

4. What is an invariant? Give examples.
Un'invariante è una regola logica che stabilisce quali sono i valori validi per lo stato di un oggetto, facendo in modo che rimanga sempre coerente.

5. When should functions be put in the class definition, and when should they be defined outside the class? Why?
Le funzioni dovrebbero essere messe nella definizione della classe solo se sono estremamente corte, grazie all'uso dell'inlining che velocizza l'esecuzione. Altrimenti dovrebbere essere implementate a parte così si separa l'interfaccia dai dettagli, tenendo pulito l'header e evitando di dover ricompilare tutto il progetto ogni volta che viene modificato il codice.