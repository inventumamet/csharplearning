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
  key_name = "temp_key"
  security_groups = [ "SSH Security" ]
  ebs_block_device {
    device_name = "/dev/sda1"
    volume_size = "16"
  }

  tags = {
    Name = var.instance_name
  }
}

resource "aws_key_pair" "temp_key" {
  key_name = "temp_key"
  public_key = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQDsCxdoaQ9fCJNFiGG+lZUIe+kaapsXHSJg9j/KG5RjWuVRwumf9BFwQErqCPHsb2CZ4oVJeofh26lQaatnyjGNl3wBHemHPbuinx1Qkg0a0rz6g4XVhXH3+jJ0H2Wnqh77R9pzrOFznXIL2xEQl/2BwgofsFxnhWFCRZvtsMTSG57MnL2bbZRZToLWYktN2YYb8bqEB/COKTykb5S4Ji8Fz523KSGVLfS+9qkG+TTux+iQvLsxfW5mQ+SF5O7jKRBVjzJWkhaL5/ztSUA2KSalF7ik1JQqKuRxszEnAV/wHjW1Zg1JUpe7TPRCAN4DMG6wE7lTS0RV++uOUtpzNnQXvDk+QkIhFkafb0UBu8AjsUmVFGbGmhy6Vzy0h7H8C9Iu9IvrH7wxwEJi6/+sRuWKMZlsXntLoJVEAdmRenjotps41FKVgWeh45Dls8XzS1gxc/ooaZmM7j0syEMtwSMjX1bz1GQJjU9M6Ts3sWODl8F6XrscCtWlG4iCAD4XQ0U= root@402e3ceb28a7"
}