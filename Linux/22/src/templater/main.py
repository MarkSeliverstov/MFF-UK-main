#!/usr/bin/env python3

import argparse
import io
import os
import sys

import jinja2
import yaml
import roman

def jinja_filter_liters_to_gallons(text):
    return float(text) * 0.2199692

def jinja_filter_liters_to_USgallons(text):
    return float(text) * 0.2641722

def jinja_filter_arabic_to_roman( val ):
    try:
        val = int(val)
    except:
        print("Warning: arabic2roman: unable to convert {}.".format(val), file = sys.stderr)
        return "NaN"
    if val <= 0:
        print("Warning: arabic2roman: unable to convert {}.".format(val), file = sys.stderr)
        return "NaN"
    return roman.toRoman( val )

def get_jinja_environment(template_dir, USgallons):
    env = jinja2.Environment(loader=jinja2.FileSystemLoader(template_dir),
                             autoescape=jinja2.select_autoescape(['html', 'xml']),
                             extensions=['jinja2.ext.do'])
    
    if USgallons:
        env.filters['l2gal'] = jinja_filter_liters_to_USgallons
    else:
        env.filters['l2gal'] = jinja_filter_liters_to_gallons

    env.filters['arabic2roman'] = jinja_filter_arabic_to_roman
    return env



def main():
    argv = sys.argv[1:]
    args = argparse.ArgumentParser(description='Templater')
    args.add_argument(
        '--template',
        dest='template',
        required=True,
        metavar='FILENAME.j2',
        help='Jinja2 template file')
    args.add_argument(
        '--input',
        dest='input',
        required=True,
        metavar='INPUT',
        help='Input filename')
    args.add_argument(
        '--use-us-gallons',
        dest='usgallons',
        required=False,
        action='store_true')
    args.add_argument(
        '-V',
        dest='var',
        required=False,
        action='append')

    config = args.parse_args(argv)

    env = get_jinja_environment(os.path.dirname(config.template), config.usgallons)
    template = env.get_template(config.template)

    content = ""
    tmp = ""
    with open(config.input, 'r') as f:
        line  = f.readline()
        
        while line != "---\n":
            line = f.readline()
        line = f.readline()

        while line != "---\n":
            tmp += line
            line = f.readline()

        content += f.read()

    tmp = yaml.safe_load( tmp )

    # DONE: extract YAML header next to these variables
    variables = {
        'content': content,
        'TEMPLATE': config.template,
        'INPUT': config.input,
    }
    
    variables = {**variables, **tmp}

    if config.var != None:
        for var in config.var:
            tmp = var.split("=")

            variables[tmp[0]] = tmp[1]

    # Use \n even on Windows
    sys.stdout = io.TextIOWrapper(sys.stdout.buffer, newline='\n')

    result = template.render(variables)

    print(result)


if __name__ == '__main__':
    main()
