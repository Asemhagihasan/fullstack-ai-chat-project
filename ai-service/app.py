import gradio as gr
from transformers import pipeline

# Load pre-trained sentiment analysis model
sentiment_pipeline = pipeline("sentiment-analysis")

# Define function for Gradio
def analyze_sentiment(text):
    result = sentiment_pipeline(text)[0]
    label = result['label']
    score = round(result['score'], 2)
    return f"{label} (confidence: {score})"

# Create Gradio interface
iface = gr.Interface(
    fn=analyze_sentiment,
    inputs=gr.Textbox(lines=2, placeholder="Type a message..."),
    outputs="text",
    title="Sentiment Analysis API",
    description="Enter a message and get Positive / Negative / Neutral sentiment."
)

# Launch for Hugging Face
iface.launch()
