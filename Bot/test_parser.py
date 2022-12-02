import unittest
from parser_input import parser
from data import question_reponse, matching_word

class TestParser(unittest.TestCase):

    def test_risque(self):
        expect = (question_reponse['risque'][0], question_reponse['risque'][1])
        resultat = parser("Quels sont les risques du sida")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])

    def test_guerir(self):
        expect = (question_reponse['guerir'][0], question_reponse['guerir'][1])
        resultat = parser("Peut-on guerir du SIDA ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])


    def test_embrasser(self):
        expect = (question_reponse['embrasser'][0], question_reponse['embrasser'][1])
        resultat = parser("Est-il risqué embrasser une personne seropositive ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])

    
    def test_parent(self):
        expect = (question_reponse['parent'][0], question_reponse['parent'][1])
        resultat = parser("Un enfant dont la mere est seropositive est-il forcément atteint par le VIH?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])


    def test_transmission(self):
        expect = (question_reponse['transmission'][0], question_reponse['transmission'][1])
        resultat = parser("Comment le virus du VIH ne se transmet pas ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])
  
    def test_prevention(self):
        expect = (question_reponse['prevention'][0], question_reponse['prevention'][1])
        resultat = parser("Qu’est-ce qu’une personne seropositive?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])

    def test_soigner(self):
        expect = (question_reponse['soigner'][0], question_reponse['soigner'][1])
        resultat = parser(" quels sont les traitements contre le VIH ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])


    def test_symptomes(self):
        expect = (question_reponse['symptomes'][0], question_reponse['symptomes'][1])
        resultat = parser("J’ai des symptomes, alors j’ai le sida ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])

    def test_attaque(self):
        expect = (question_reponse['attaque'][0], question_reponse['attaque'][1])
        resultat = parser(" Dans l’organisme, à quoi attaque le VIH ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])

    def test_question(self):
        expect = (question_reponse['question'][0], question_reponse['question'][1])
        resultat = parser(" Pour toute question concernant le SIDA, j’appelle :")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])


    def test_default(self):
        expect = (question_reponse['sida'][0], question_reponse['sida'][1])
        resultat = parser(" qu'est ce que le sida ?")
        print(resultat[0], resultat[1])
      
        self.assertEqual(expect[0], resultat[0])
        self.assertEqual(expect[1], resultat[1])

if __name__ == '__main__':
    unittest.main()