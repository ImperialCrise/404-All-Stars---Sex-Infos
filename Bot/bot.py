import discord
from dotenv import load_dotenv
import os

intents = discord.Intents.all()
intents.message_content = True
client = discord.Client(intents=intents)
intents.members = True
load_dotenv()


def get_response(message):
    response = ""
    match message:
        case "!help":
            response = "Essaie les commandes suivantes:\n"
            response += "   -> **!help**"
        case _:
            response = "Je n'ai pas compris."
    
    return response

def parseur(message):
    return

@client.event
async def on_ready():
    print("Bot connected.")

@client.event
async def on_member_join(member):
    await member.send("Bienvenue à toi!")

@client.event
async def on_message(message):
    # Message ne provenant pas du bot
    if message.author != client.user:

        # Message privé reçu
        if isinstance(message.channel, discord.channel.DMChannel) and message.author != client.user:
            await send_response(message)

        # Commande
        elif message.content[0] == '!' and len(message.content) > 1:
            await send_command_response(message)
        

        elif message.content == "Are u here?":
            await send_priv_message(message)

        elif message.content.lower() == "ready":
            await message.channel.send("yesss")
        

async def send_response(message):
    response = parseur(message.content)
    await message.channel.send("response")

async def send_priv_message(message):
    response = "Of course!"
    await message.author.send(response)

async def send_command_response(message):
    await message.channel.send(get_response(message.content))


client.run(os.getenv("TOKEN"))  