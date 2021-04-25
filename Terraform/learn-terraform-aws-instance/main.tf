terraform {
  required_providers {
    aws = {
      source  = "hashicorp/aws"
      version = "~> 3.27"
    }
  }

  required_version = ">= 0.14.9"
}

provider "aws" {
  profile = "maoneng-sandbox"
  region  = "ap-southeast-2"
}

resource "aws_instance" "app_server" {
#   ami           = "ami-06202e06492f46177" # default Amazon Linux
  ami = "ami-0a43280cfb87ffdba" # default Ubuntu
  instance_type = "t2.micro"

  tags = {
    Name = "ExampleAppServerInstance"
  }
}