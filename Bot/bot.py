import discord
from dotenv import load_dotenv
import os
from parser_input import parser

intents = discord.Intents.all()
intents.messages = True
client = discord.Client(intents=intents)
intents.members = True
load_dotenv()


def get_command_response(message):
    response = ""
    match message:
        case "!help":
            response = "Essaie les commandes suivantes:\n"
            response += "   -> **!help** , pour obtenir l'ensemble des commandes disponibles."
        case _:
            response = "Je n'ai pas compris. Essaie à nouveau?"
    
    return response


@client.event
async def on_ready():
    print("Bot connected.")

@client.event
async def on_member_join(member):
    await member.send("Bienvenue à toi!\nN'hesite pas à poser tes questions ici, ou bien utiliser la commande **!help** pour en savoir plus :wink:\n")

@client.event
async def on_message(message):
    # Message ne provenant pas du bot et dans le bon channel
    if message.author != client.user:
        if message.content == "ping?":
            await message.reply("pong")

        # Commande
        elif message.content[0] == '!' and len(message.content) > 1:
            await send_command_response(message)
        
        else:
            await send_response(message)



        

async def send_response(message):
    if (not isinstance(message.channel, discord.channel.DMChannel)):
        await message.reply("Regarde tes DM pour avoir plus d'informations :relaxed:")
    response,link = parser(message.content)
    response = "*"+response+"*"
    await message.author.send(response)
    link = "> "+link
    await message.author.send(link)


# Envoie dans le channel adéquat la man page du bot
async def send_command_response(message):
    await message.channel.send(get_command_response(message.content))


client.run(os.getenv("TOKEN"))  