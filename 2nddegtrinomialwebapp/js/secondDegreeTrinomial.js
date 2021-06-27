//This function gets the input parameters of the trinomial, calculates related data (delta, solutions) and wraps all as an abject.
function getData(){
  let trinomial = {}
    trinomial.a = document.modulo.a.value;
    trinomial.b = document.modulo.b.value;
    trinomial.c = document.modulo.c.value;
    trinomial.d = Math.pow(trinomial.b, 2)- 4*trinomial.a*trinomial.c;
    trinomial.x1 = (-trinomial.b - Math.sqrt(trinomial.d))/(2*trinomial.a);
    trinomial.x2 =  (-trinomial.b + Math.sqrt(trinomial.d))/(2*trinomial.a);
  return trinomial;
}

//This function clears all the fields of the form when the corresponding button is clicked.
function clearFields() {
  document.modulo.a.value = "";
  document.modulo.b.value = "";
  document.modulo.c.value = "";
  document.modulo.delta.value = "";
  document.modulo.messageSolutions.value = "";
  document.modulo.messageSign.value = "";
}

//This function analyses parameters and delta to define solutions (if existing) and to study the sign of the trinomial.
function giveSolutions(){
  let trinomial = getData();
  let risultato;
  let risultatoDelta;
  let risultatoSegno;
  let signOfa;
  let inverseSign;

  if ((isNaN(trinomial.a)) || (isNaN(trinomial.b)) || (isNaN(trinomial.c))) {
    risultato = "Attenzione, solo valori numerici ammessi come parametri!";
    risultatoSegno = "Attenzione, solo valori numerici ammessi come parametri!";
    risultatoDelta = ""
  }
  else {
  risultatoDelta = trinomial.d;
  if (trinomial.a==0){
    risultato = `Attenzione, deve essere a\u22600 affinché il trinomio sia di 2° grado`;
    risultatoSegno = `Attenzione, deve essere a\u22600 affinché il trinomio sia di 2° grado`;
    risultatoDelta = ""
  }
  else {
    if (trinomial.a>0){
      signOfa = "positivo";
      inverseSign = "negativo"
    }
    else {
      signOfa = "negativo";
      inverseSign = "positivo";
    }
    if (trinomial.d<0) {
      risultato = "Le soluzioni sono l'insieme vuoto {0}, cioè il trinomio non ha soluzioni reali, perché il \u0394 è negativo";
      risultatoSegno = `Il trinomio è ${signOfa} per ogni valore di x, cioè ha sempre il segno di a, perché il \u0394 è negativo`;
    }
    else if (trinomial.d==0) {
      risultato = `Il trinomio ha due soluzioni reali coincidenti che sono x\u2081=x\u2082=${trinomial.x1}`;
      risultatoSegno = `Il trinomio è uguale a zero per x=${trinomial.x1} (valore delle due soluzioni coincidenti), per ogni altro valore di x il trinomio ha segno ${signOfa}`;
    }
    else {
      let min = Math.min(trinomial.x1, trinomial.x2);
      let max = Math.max(trinomial.x1, trinomial.x2);
      risultatoSegno = `Il trinomio è ${signOfa} negli intervalli esterni x<${min} e x>${max}, mentre è ${inverseSign} nell'intervallo interno ${min}<x<${max}`;
      if (trinomial.b==0 && trinomial.c!=0) {
        risultato = `Il trinomio ha due soluzioni reali e opposte che sono x\u2081=${trinomial.x1} e x\u2082=${trinomial.x2}`;
      }
      else {
        risultato = `Il trinomio ha due soluzioni reali e distinte che sono x\u2081=${trinomial.x1} e x\u2082=${trinomial.x2}`;
      }
    }
  }
}

document.modulo.delta.value = risultatoDelta;
document.modulo.messageSolutions.value = risultato;
document.modulo.messageSign.value = risultatoSegno;
}
