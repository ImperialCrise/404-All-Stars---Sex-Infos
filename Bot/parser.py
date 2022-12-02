import re
from data import question_reponse, matching_word

def check_word(input, target):
  input=input.split()
  for word in input:
    if re.match(r'{0}*'.format(matching_word[target]), word.casefold()):
      return True
  return False

def parser(input):
  if check_word(input, 'risque'):
    return(question_reponse['risque'][0], question_reponse['risque'][1])
    
  if check_word(input, 'guerir'):
    return(question_reponse['guerir'][0], question_reponse['guerir'][1])

  if check_word(input, 'seropositif') :
    if check_word(input, 'embrasser') or check_word(input, 'carresser'):
      return(question_reponse['embrasser'][0], question_reponse['embrasser'][1])
      
    if check_word(input, 'mere') or check_word(input, 'enfant'):
      return (question_reponse['parent'][0], question_reponse['parent'][1])

  if check_word(input, 'transmet'):
    return (question_reponse['transmission'][0], question_reponse['transmission'][1])

  ##VIH
  if check_word(input, 'vih') or check_word(input, 'sida'):
    if check_word(input, 'prevention'):
      return(question_reponse['prevention'][0], question_reponse['prevention'][1])
      
    if check_word(input, 'soigner') or check_word(input, 'traitement'):
      return(question_reponse['soigner'][0], question_reponse['soigner'][1])
      
    if check_word(input, 'symptomes'):
      return (question_reponse['symptomes'][0], question_reponse['symptomes'][1])

    ##attack
    if check_word(input, 'attaque') or check_word(input, 'organisme') :
      return (question_reponse['attaque'][0], question_reponse['attaque'][1])
      
    if check_word(input, 'question'):
      return (question_reponse['question'][0], question_reponse['question'][1])
      
  return(question_reponse['sida'][0], question_reponse['sida'][1])