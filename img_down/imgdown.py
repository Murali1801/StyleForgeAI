import os
import json
import requests
from PIL import Image
from io import BytesIO

# Folder to save the images
output_folder = "C:\Users\mural\source\repos\StyleForgeAI\img_down\outputs"

# Create the output folder if it doesn't exist
if not os.path.exists(output_folder):
    os.makedirs(output_folder)

def download_and_save_image(image_url, filename):
    try:
        # Send a GET request to fetch the image
        response = requests.get(image_url)
        response.raise_for_status()  # Check for request errors
        
        # Open the image from the response
        image = Image.open(BytesIO(response.content))
        
        # If the image is not in JPG format, convert it to JPG
        if image.format != 'JPEG':
            filename = filename.rsplit('.', 1)[0] + '.jpg'  # Change extension to .jpg
            image = image.convert('RGB')  # Convert image to RGB (necessary for JPG)
        
        # Save the image in the output folder with the correct format
        image.save(os.path.join(output_folder, filename), 'JPEG')
        print(f"Image saved as {filename}")
    
    except requests.exceptions.RequestException as e:
        print(f"Error downloading image from {image_url}: {e}")
    except Exception as e:
        print(f"Error processing image {image_url}: {e}")


def process_images(data):
    count = 0
    # Print data structure for debugging
    print("Data structure:", data)

    # Check if the data is a dictionary or a list of dictionaries
    if isinstance(data, dict):
        # Process dictionary directly
        for key, value in data.items():
            if isinstance(value, str) and key.endswith('_image_url'):  # Check for URL string
                count += 1
                print(f"Found URL for {key}: {value}")
                # Extract the key's name (remove '_image_url' suffix) for filename
                filename = key.rsplit('_', 1)[0] + '.jpg'
                download_and_save_image(value, filename)
    elif isinstance(data, list):
        # Process list of strings (if they are in key-value pairs)
        for item in data:
            if isinstance(item, dict):
                for key, value in item.items():
                    if isinstance(value, str) and key.endswith('_image_url'):
                        count += 1
                        print(f"Found URL for {key}: {value}")
                        filename = key.rsplit('_', 1)[0] + '.jpg'
                        download_and_save_image(value, filename)
            elif isinstance(item, str) and item.endswith('_image_url'):
                # Directly handle string URLs
                count += 1
                print(f"Found URL: {item}")
                filename = item.split('/')[-1]
                download_and_save_image(item, filename)
            else:
                print(f"Item is not a URL or dict: {item}")
    else:
        print("Data is neither a dictionary nor a list.")

    print(f"Total number of '_image_url' keys found: {count}")



if __name__ == "__main__":
    # Path to the JSON file
    json_file_path = os.path.join(os.path.dirname(__file__), 'image_data.json')

    # Read the JSON file
    if os.path.exists(json_file_path):
        with open(json_file_path, 'r') as file:
            try:
                image_data = json.load(file)
                process_images(image_data)
            except json.JSONDecodeError as e:
                print(f"Error reading JSON file: {e}")
    else:
        print(f"JSON file not found at {json_file_path}")
